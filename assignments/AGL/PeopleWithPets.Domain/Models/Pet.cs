using System;
using PeopleWithPets.Domain.Enums;

namespace PeopleWithPets.Domain.Models
{
    /// <summary>
    /// POCO type to represent a Pet
    /// </summary>
    public class Pet
    {
        private readonly string _name;
        private readonly PetType _type;

        public string Name { get { return _name; } }
        public PetType Type { get { return _type; } }

        public Pet(string name, PetType type)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            _name = name;
            _type = type;
        }
    }
}