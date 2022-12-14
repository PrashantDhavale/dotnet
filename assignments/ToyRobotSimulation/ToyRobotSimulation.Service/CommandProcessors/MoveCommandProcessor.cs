using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service.CommandProcessors
{
    public class MoveCommandProcessor : BaseCommandProcessor
    {
        public MoveCommandProcessor(string[] commands, IToyRobot toyRobot) : base(commands, toyRobot)
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
            if (commandType != CommandType.Move)
                return false;

            return true;
        }

        public override void ProcessMovement()
        {
            bool isValid = Validate();
            if (!isValid)
                return;

            SetCoordinates();
        }

        private void SetCoordinates()
        {
            // get the current X,Y coordinates
            uint calculatedX = _toyRobotInstance.X;
            uint calculatedY = _toyRobotInstance.Y;

            // check cardinal direction and adjust coordinates respectively

            if (_toyRobotInstance.CardinalDirection.Value == CardinalDirection.North)
                calculatedY += Constants.MAX_MOVE_PLACES;

            if (_toyRobotInstance.CardinalDirection.Value == CardinalDirection.South)
                calculatedY -= Constants.MAX_MOVE_PLACES;

            if (_toyRobotInstance.CardinalDirection.Value == CardinalDirection.East)
                calculatedX += Constants.MAX_MOVE_PLACES;

            if (_toyRobotInstance.CardinalDirection.Value == CardinalDirection.West)
                calculatedX -= Constants.MAX_MOVE_PLACES;

            // assign the new coordinates
            _toyRobotInstance.SetCoordinates(calculatedX, calculatedY);
        }
    }
}