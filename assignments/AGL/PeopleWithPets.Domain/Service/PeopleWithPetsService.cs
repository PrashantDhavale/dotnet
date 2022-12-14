using System;
using PeopleWithPets.Domain.Repository;
using System.Collections.Generic;

namespace PeopleWithPets.Domain.Service
{
    /// <summary>
    /// Type for all the services of People with Pets
    /// </summary>
    public class PeopleWithPetsService
    {
        private readonly PeopleWithPetsRepository _repository;

        /// <summary>
        /// Constructor with Dependency Injection
        /// </summary>
        /// <param name="repository">Repository instance</param>
        public PeopleWithPetsService(PeopleWithPetsRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            _repository = repository;
        }

        public IEnumerable<Domain.Models.CatsGroupedByOwnersGender> GetCatsGroupedByOwnersGender()
        {
            // Call the method and return
             return _repository.GetCatsGroupedByOwnersGender(); ;
        }
    }
}
