using System;
using Xunit;
using PeopleWithPets.DataAccess.Repository;
using Moq;
using System.Collections.Generic;
using PeopleWithPets.Domain.Repository;

namespace PeopleWithPets.DataAccess.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void CreateWithNull_HttpClientPeopleWithPetsRepositoryWillThrow()
        {
            // Arrange act and assert
            Assert.Throws<ArgumentNullException>(() => new HttpClientPeopleWithPetsRepository(null));
        }

        [Fact]
        public void GetCatsGroupedByOwnersGender_ShouldReturnNonNull()
        {
            // Arrange
            Mock<PeopleWithPetsRepository> mockRepo = new Mock<PeopleWithPetsRepository>();
            mockRepo.Setup(pro => pro.GetCatsGroupedByOwnersGender()).Returns(GetTestCatsGroupedByOwnersGender());

            // Act
            var result = mockRepo.Object.GetCatsGroupedByOwnersGender();
            
            // Assert
            Assert.NotNull(result);
        }

        private IEnumerable<Domain.Models.CatsGroupedByOwnersGender> GetTestCatsGroupedByOwnersGender()
        {
            List<Domain.Models.CatsGroupedByOwnersGender> l = new List<Domain.Models.CatsGroupedByOwnersGender>();
            l.Add(new Domain.Models.CatsGroupedByOwnersGender(Domain.Enums.PersonGender.Male, new string[] { "a", "b" }));
            l.Add(new Domain.Models.CatsGroupedByOwnersGender(Domain.Enums.PersonGender.Female, new string[] { "b","c" }));

            return l;
        }
    }
}
