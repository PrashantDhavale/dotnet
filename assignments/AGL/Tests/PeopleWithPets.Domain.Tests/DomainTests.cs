using System;
using Xunit;
using PeopleWithPets.Domain.Models;

namespace PeopleWithPets.Domain.Tests
{
    public class DomainTests
    {
        [Fact]
        public void CreateWithNull_CatsGroupedByOwnersGenderWillThrow_OnNullCats()
        {
            // Arrange, Act and assert
            Assert.Throws<ArgumentNullException>(() => new CatsGroupedByOwnersGender(Enums.PersonGender.Female, null));
        }

        [Fact]
        public void CreateWithNull_PersonWillThrow_OnNullName()
        {
            // Arrange, Act and assert
            Assert.Throws<ArgumentNullException>(() => new Person(null, Enums.PersonGender.Female, 25, null));
        }

        [Fact]
        public void CreateWithNull_PetWillThrow_OnNullName()
        {
            // Arrange, Act and assert
            Assert.Throws<ArgumentNullException>(() => new Pet(null, Enums.PetType.Cat));
        }
    }
}
