using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;
using ToyRobotSimulation.Service.CommandProcessors;
using Xunit;

namespace ToyRobotSimulation.Tests
{
    public class RightCommandProcessorTests
    {
        [Theory]
        [InlineData(CardinalDirection.North, CardinalDirection.East)]
        [InlineData(CardinalDirection.South, CardinalDirection.West)]
        [InlineData(CardinalDirection.East, CardinalDirection.South)]
        [InlineData(CardinalDirection.West, CardinalDirection.North)]
        public void Face_Right_Tests(CardinalDirection actualCardinalDirection, CardinalDirection expectedCardinalDirection)
        {
            // Arrange

            var toyRobot = new ToyRobot();
            toyRobot.SetCoordinates(1, 1);
            toyRobot.SetCardinalDirection(actualCardinalDirection);

            string[] commands = new string[] { "right" };

            // Act 

            ICommandProcessor commandProcessor = new RightCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();
            // Assert

            Assert.Equal(expectedCardinalDirection, toyRobot.CardinalDirection);
        }

        [Theory]
        [InlineData("", CardinalDirection.North)]
        [InlineData("a", CardinalDirection.North)]
        [InlineData("lost", CardinalDirection.North)]
        [InlineData("blah", CardinalDirection.East)]
        [InlineData("hell", CardinalDirection.West)]
        public void Invalid_Right_Command_Should_Not_Change_State(string commandString, CardinalDirection actualCardinalDirection)
        {
            // Arrange

            var toyRobot = new ToyRobot();
            toyRobot.SetCoordinates(1, 1);
            toyRobot.SetCardinalDirection(actualCardinalDirection);

            string[] commands = new string[] { commandString };

            // Act 

            ICommandProcessor commandProcessor = new RightCommandProcessor(commands, toyRobot);
            commandProcessor.ProcessMovement();

            // Assert

            Assert.Equal(actualCardinalDirection, toyRobot.CardinalDirection);
        }
    }
}