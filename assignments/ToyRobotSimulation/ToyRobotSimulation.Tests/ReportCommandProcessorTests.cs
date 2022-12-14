using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;
using ToyRobotSimulation.Service.CommandProcessors;
using Xunit;

namespace ToyRobotSimulation.Tests
{
    public class ReportCommandProcessorTests
    {
        [Fact]
        public void Report_Without_Placement_Should_Not_Work()
        {
            // Arrange

            string[] commands = new string[] { "report" };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor commandProcessor = new ReportCommandProcessor(commands, toyRobot);
            string report = commandProcessor.GenerateReport();

            // Assert

            Assert.Equal<uint>(0, toyRobot.X);
            Assert.Equal<uint>(0, toyRobot.Y);
            Assert.False(toyRobot.IsPlaced);
            Assert.Null(toyRobot.CardinalDirection);
            Assert.Equal(string.Empty, report);
        }

        [Fact]
        public void Report_After_Placement_Should_Work()
        {
            // Arrange
            string[] placeCommands = new string[] { "place", "1", "1", "North" };
            string[] commands = new string[] { "report" };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor placeCommandProcessor = new PlaceCommandProcessor(placeCommands, toyRobot);
            placeCommandProcessor.ProcessMovement();

            ICommandProcessor commandProcessor = new ReportCommandProcessor(commands, toyRobot);
            string report = commandProcessor.GenerateReport();

            // Assert

            Assert.Equal<uint>(1, toyRobot.X);
            Assert.Equal<uint>(1, toyRobot.Y);
            Assert.True(toyRobot.IsPlaced);
            Assert.NotEqual(string.Empty, report);
            Assert.Equal(CardinalDirection.North, toyRobot.CardinalDirection);
        }
    }
}