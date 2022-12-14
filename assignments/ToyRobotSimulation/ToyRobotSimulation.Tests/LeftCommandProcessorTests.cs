using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;
using ToyRobotSimulation.Service.CommandProcessors;
using Xunit;

namespace ToyRobotSimulation.Tests
{
    public class LeftCommandProcessorTests
    {
        [Theory]
        [InlineData(CardinalDirection.North, CardinalDirection.West)]
        [InlineData(CardinalDirection.South, CardinalDirection.East)]
        [InlineData(CardinalDirection.East, CardinalDirection.North)]
        [InlineData(CardinalDirection.West, CardinalDirection.South)]
        public void Face_Left_Tests(CardinalDirection actualCardinalDirection, CardinalDirection expectedCardinalDirection)
        {
            // Arrange

            var toyRobot = new ToyRobot();
            toyRobot.SetCoordinates(1, 1);
            toyRobot.SetCardinalDirection(actualCardinalDirection);

            string[] commands = new string[] { "left" };

            // Act 

            ICommandProcessor commandProcessor = new LeftCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();

            // Assert

            Assert.Equal(expectedCardinalDirection, toyRobot.CardinalDirection);
        }

        [Theory]
        [InlineData("",CardinalDirection.North)]
        [InlineData("a", CardinalDirection.North)]
        [InlineData("lost", CardinalDirection.North)]
        [InlineData("blah",CardinalDirection.East)]
        [InlineData("hell",CardinalDirection.West)]
        public void Invalid_Left_Command_Should_Not_Change_State(string commandString,CardinalDirection actualCardinalDirection)
        {
            // Arrange

            var toyRobot = new ToyRobot();
            toyRobot.SetCoordinates(1, 1);
            toyRobot.SetCardinalDirection(actualCardinalDirection);

            string[] commands = new string[] { commandString };

            // Act 

            ICommandProcessor commandProcessor = new LeftCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();

            // Assert

            Assert.Equal(actualCardinalDirection, toyRobot.CardinalDirection);
        }
    }
}