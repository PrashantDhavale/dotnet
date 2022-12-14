using System;
using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;
using ToyRobotSimulation.Service.CommandProcessors;
using Xunit;

namespace ToyRobotSimulation.Tests
{
    public class PlaceCommandProcessorTests
    {
        [Fact]
        public void Placement_With_Direction_Should_Change_State()
        {
            // Arrange

            string[] commands = new string[] { "place", "1", "1", "North" };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor commandProcessor = new PlaceCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();

            // Assert

            Assert.Equal<uint>(1, toyRobot.X);
            Assert.Equal<uint>(1, toyRobot.Y);
            Assert.True(toyRobot.IsPlaced);
            Assert.Equal(CardinalDirection.North,toyRobot.CardinalDirection);
        }

        [Fact]
        public void Placement_On_Non_Placed_Robot_Should_Not_Change_State()
        {
            // Arrange

            string[] commands = new string[] { "place", "1", "1" };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor commandProcessor = new PlaceCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();

            // Assert

            Assert.Equal<uint>(0, toyRobot.X);
            Assert.Equal<uint>(0, toyRobot.Y);
            Assert.False(toyRobot.IsPlaced);
            Assert.Null(toyRobot.CardinalDirection);
        }

        //Note current max_tabletop_bound is set to 5.
        //If that changes the tests here will need to be adjusted. 
        //Plan a data generator instead of hard coding.
        [Theory]
        [InlineData("6","6","North")]
        [InlineData("1","6","North")]
        [InlineData("-1", "-6","North")]
        [InlineData("5", "-6","North")]
        [InlineData("a", "a", "a")]
        public void Placement_Should_Not_Set_With_Incorrect_Values(string x, string y, string direction)
        {
            // Arrange

            string[] commands = new string[] { "place", x, y, direction };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor commandProcessor = new PlaceCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();

            // Assert

            Assert.Equal<uint>(0, toyRobot.X);
            Assert.Equal<uint>(0, toyRobot.Y);
            Assert.False(toyRobot.IsPlaced);
            Assert.Null(toyRobot.CardinalDirection);
        }

        [Theory]
        [InlineData("1", "5", "North")]
        [InlineData("2", "4", "East")]
        [InlineData("3", "3", "West")]
        [InlineData("4", "2", "South")]
        [InlineData("5", "1", "North")]
        public void Placement_Should_Work_With_Correct_Values(string x, string y, string direction)
        {
            // Arrange

            string[] commands = new string[] { "place", x, y, direction };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor commandProcessor = new PlaceCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();

            // Assert

            uint.TryParse(x, out uint proposedX);
            uint.TryParse(y, out uint proposedY);
            Enum.TryParse(direction, true, out CardinalDirection proposedDirection);

            Assert.Equal<uint>(proposedX, toyRobot.X);
            Assert.Equal<uint>(proposedY, toyRobot.Y);
            Assert.True(toyRobot.IsPlaced);
            Assert.Equal(proposedDirection,toyRobot.CardinalDirection);
        }
    }
}