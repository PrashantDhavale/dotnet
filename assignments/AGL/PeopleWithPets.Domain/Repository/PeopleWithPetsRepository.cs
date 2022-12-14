using System.Collections.Generic;

namespace PeopleWithPets.Domain.Repository
{
    /// <summary>
    /// Abstract type for the repository that should return an IEnumerable of CatsGroupedByOwnersGender model
    /// </summary>
    public abstract class PeopleWithPetsRepository
    {
        public abstract IEnumerable<Domain.Models.CatsGroupedByOwnersGender> GetCatsGroupedByOwnersGender();
    }
}