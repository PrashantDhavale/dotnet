using PeopleWithPets.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PeopleWithPets.Domain.Models
{
    /// <summary>
    /// POCO type representing cats grouped by owners gender
    /// </summary>
    public class CatsGroupedByOwnersGender
    {
        private PersonGender _ownersGender;
        private IEnumerable<string> _catNames;

        public PersonGender OwnersGender { get { return _ownersGender; } }
        public IEnumerable<string> CatNames { get { return _catNames; } }

        public CatsGroupedByOwnersGender(PersonGender ownersGender, IEnumerable<string> catNames)
        {
            if(catNames == null)
            {
                throw new ArgumentNullException(nameof(catNames));
            }

            _ownersGender = ownersGender;
            _catNames = catNames;
        }
    }
}