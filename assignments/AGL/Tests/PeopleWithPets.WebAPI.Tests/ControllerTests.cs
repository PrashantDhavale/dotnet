using System;
using Moq;
using Xunit;
using PeopleWithPets.Domain.Repository;
using PeopleWithPets.WebAPI.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PeopleWithPets.WebAPI.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void CreateWithNull_ControllerWillThrow()
        {
            // Arrange act and assert
            Assert.Throws<ArgumentNullException>(() => new PeopleWithPetsController(null, null));
        }

        [Fact]
        public void CreateWithNull_PeopleWithPetsRepositoryWillThrow()
        {

            // Arrange
            var mockLogger = new Mock<ILogger<PeopleWithPetsController>>();

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new PeopleWithPetsController(null, mockLogger.Object));
        }

        [Fact]
        public void CreateWithNull_ILoggerWillThrow()
        {

            // Arrange
            var mockRepo = new Mock<PeopleWithPetsRepository>();
            var mockLogger = new Mock<ILogger<PeopleWithPetsController>>();

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new PeopleWithPetsController(mockRepo.Object, null));
        }

        [Fact]
        public void GetCatsGroupedByOwnersGender_ReturnsOk()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<PeopleWithPetsController>>();
            var mockRepo = new Mock<PeopleWithPetsRepository>();
            mockRepo.Setup(pro => pro.GetCatsGroupedByOwnersGender()).Returns(GetTestCatsGroupedByOwnersGender());

            var controller = new PeopleWithPetsController(mockRepo.Object, mockLogger.Object);

            // Act
            var result = controller.GetCatsGroupedByOwnersGender();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnModel = Assert.IsAssignableFrom<IEnumerable<Domain.Models.CatsGroupedByOwnersGender>>(okResult.Value);
            Assert.Equal(200, okResult.StatusCode.Value);
        }

        [Fact]
        public void Create_GivenInvalidModel_ReturnsBadRequest()
        {
            // Arrange & Act
            var mockLogger = new Mock<ILogger<PeopleWithPetsController>>();
            var mockRepo = new Mock<PeopleWithPetsRepository>();
            var controller = new PeopleWithPetsController(mockRepo.Object, mockLogger.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = controller.GetCatsGroupedByOwnersGender();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        private IEnumerable<Domain.Models.CatsGroupedByOwnersGender> GetTestCatsGroupedByOwnersGender()
        {
            List<Domain.Models.CatsGroupedByOwnersGender> l = new List<Domain.Models.CatsGroupedByOwnersGender>();
            l.Add(new Domain.Models.CatsGroupedByOwnersGender(Domain.Enums.PersonGender.Male, new string[] { "a" }));
            l.Add(new Domain.Models.CatsGroupedByOwnersGender(Domain.Enums.PersonGender.Female, new string[] { "b" }));

            return l;
        }
    }
}
