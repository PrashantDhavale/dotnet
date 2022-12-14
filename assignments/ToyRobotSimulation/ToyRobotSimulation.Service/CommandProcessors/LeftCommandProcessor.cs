using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service.CommandProcessors
{
    public class LeftCommandProcessor : BaseCommandProcessor
    {
        public LeftCommandProcessor(string[] commands, IToyRobot toyRobot) : base(commands, toyRobot)
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
            if (commandType != CommandType.Left)
                return false;

            return true;
        }

        public override void ProcessMovement()
        {
            bool isValid = Validate();
            if (!isValid)
                return;

            var proposedCardinalDirection = Mappings.DirectionMapping[$"{_toyRobotInstance.CardinalDirection}{RelativeDirection.Left}"];
            _toyRobotInstance.SetCardinalDirection(proposedCardinalDirection);
        }
    }
}