using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Options;
using PeopleWithPets.DataAccess.Settings;

namespace PeopleWithPets.DataAccess.Repository
{
    /// <summary>
    /// Type to implement repository
    /// </summary>
    public class HttpClientPeopleWithPetsRepository : Domain.Repository.PeopleWithPetsRepository
    {
        /// <summary>
        /// IOptions to get the dependant settings
        /// </summary>
        private readonly IOptions<RepositorySettings> _settings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings">An IOption RepositorySetting that contains the serice end point</param>
        public HttpClientPeopleWithPetsRepository(IOptions<RepositorySettings> settings)
        {
            if(settings == null)
            { 
                throw new ArgumentNullException(nameof(settings));
            }

            _settings = settings;
        }

        /// <summary>
        /// Method to Load the HttpClient data containing the people and pets information.
        /// </summary>
        /// <returns>All cats ordered by name and grouped by owners gender</returns>
        public override IEnumerable<Domain.Models.CatsGroupedByOwnersGender> GetCatsGroupedByOwnersGender()
        {
            var persons = LoadHttpClientData(_settings.Value.ServiceEndPoint);

            if (persons == null)
                return null;

            // Get all pets of type Cat
            // Create an anonymous type containing owners gender and Cats name
            var query = from person in persons.Result
                        from pet in person.Pets
                                    .Where(p => p.Type == Domain.Enums.PetType.Cat)
                                    .OrderBy(o => o.Name).DefaultIfEmpty()
                        select new
                        {
                            Gender = person.Gender,
                            CatsName = pet?.Name
                        };

            // Group the result by owners gender and filter null ones.
            var grouped = query
                .Where(c => c.CatsName != null)
                .GroupBy(g => g.Gender)
                .Select(s => new Domain.Models.CatsGroupedByOwnersGender(s.Key, s.Select(i => i.CatsName)));

            return grouped;
        }

        private async Task<List<Domain.Models.Person>> LoadHttpClientData(string baseUrl)
        {
            List<Domain.Models.Person> persons;
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include
            };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
            using (HttpContent content = res.Content)
            {
                //Read the data as string and deserialize into list of Person model
                string data = await content.ReadAsStringAsync();
                persons = !string.IsNullOrEmpty(data)
                             ? JsonConvert.DeserializeObject<List<Domain.Models.Person>>(data, jsonSettings)
                             : default(List<Domain.Models.Person>);
            } //dispose

            return persons;
        }
    }
}