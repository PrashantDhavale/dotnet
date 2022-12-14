using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service.CommandProcessors
{
    public class RightCommandProcessor : BaseCommandProcessor
    {
        public RightCommandProcessor(string[] commands, IToyRobot toyRobot) : base(commands, toyRobot)
        {
        }

        public override bool Validate()
        {
            var isValid = base.Validate();

            if (!isValid)
                return false;

            var commandType = HelperMethods.EvaluateCommandType(_commands);
            if (!commandType.HasValue)
                return false;
            if (commandType != CommandType.Right)
                return false;

            return true;
        }

        public override void ProcessMovement()
        {
            bool isValid = Validate();
            if (!isValid)
                return;

            var proposedCardinalDirection = Mappings.DirectionMapping[$"{_toyRobotInstance.CardinalDirection}{RelativeDirection.Right}"];
            _toyRobotInstance.SetCardinalDirection(proposedCardinalDirection);
        }
    }
}