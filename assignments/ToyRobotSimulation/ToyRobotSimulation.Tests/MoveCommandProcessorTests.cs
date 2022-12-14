using System;
using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;
using ToyRobotSimulation.Service.CommandProcessors;
using Xunit;

namespace ToyRobotSimulation.Tests
{
    public class MoveCommandProcessorTests
    {
        [Fact]
        public void Move_Without_Placement_Should_Not_Change_State()
        {
            // Arrange

            string[] commands = new string[] { "move" };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor commandProcessor = new MoveCommandProcessor(commands, toyRobot);
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
        [InlineData("0", "5", "North")]
        [InlineData("0", "4", "West")]
        [InlineData("5", "4", "East")]
        [InlineData("5", "0", "South")]
        public void Move_Should_Not_Set_Beyond_Bounds(string x, string y, string direction)
        {
            // Arrange

            string[] placeCommands = new string[] { "place", x, y, direction };
            string[] moveCommands = new string[] { "move" };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor placeCommandProcessor = new PlaceCommandProcessor(placeCommands, toyRobot);
            placeCommandProcessor.ProcessMovement();

            ICommandProcessor moveCommandProcessor = new MoveCommandProcessor(moveCommands, toyRobot);
            moveCommandProcessor.ProcessMovement();

            // Assert
            uint.TryParse(x, out uint proposedX);
            uint.TryParse(y, out uint proposedY);
            Enum.TryParse(direction, true, out CardinalDirection proposedDirection);

            Assert.Equal<uint>(proposedX, toyRobot.X);
            Assert.Equal<uint>(proposedY, toyRobot.Y);
            Assert.True(toyRobot.IsPlaced);
            Assert.Equal(proposedDirection, toyRobot.CardinalDirection);
        }

        [Theory]
        [InlineData("1", "4", "North", "1", "5")]
        [InlineData("2", "4", "East", "3", "4")]
        [InlineData("3", "3", "West", "2", "3")]
        [InlineData("4", "2", "South", "4", "1")]
        [InlineData("5", "1", "North", "5", "2")]
        public void Move_Should_Work_With_Correct_Values(string x, string y, string direction, string moveX, string moveY)
        {
            // Arrange

            string[] placeCommands = new string[] { "place", x, y, direction };
            string[] moveCommands = new string[] { "move" };

            // Act 

            var toyRobot = new ToyRobot();

            ICommandProcessor placeCommandProcessor = new PlaceCommandProcessor(placeCommands, toyRobot);
            placeCommandProcessor.ProcessMovement();

            ICommandProcessor moveCommandProcessor = new MoveCommandProcessor(moveCommands, toyRobot);
            moveCommandProcessor.ProcessMovement();

            // Assert


            Enum.TryParse(direction, true, out CardinalDirection proposedDirection);
            uint.TryParse(moveX, out uint proposedMoveX);
            uint.TryParse(moveY, out uint proposedMoveY);

            Assert.Equal<uint>(proposedMoveX, toyRobot.X);
            Assert.Equal<uint>(proposedMoveY, toyRobot.Y);
            Assert.True(toyRobot.IsPlaced);
            Assert.Equal(proposedDirection, toyRobot.CardinalDirection);
        }
    }
}