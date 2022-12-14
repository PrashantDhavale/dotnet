using System;
using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service.CommandProcessors
{
    public class PlaceCommandProcessor : BaseCommandProcessor
    {
        public PlaceCommandProcessor(string[] commands, IToyRobot toyRobot) : base(commands, toyRobot)
        {
        }

        public override void ProcessMovement()
        {
            bool isValid = Validate();
            if (!isValid)
                return;

            SetCoordinates();
            SetCardinalDirection();
        }

        public override bool Validate()
        {
            // check the expected command length
            if (_commands.Length < 3 || _commands.Length > 4)
                return false;

            var commandType = HelperMethods.EvaluateCommandType(_commands);
            if (!commandType.HasValue)
                return false;
            if (commandType != CommandType.Place)
                return false;

            // cast and validate the proposed values
            uint proposedX, proposedY = 0;

            if (!uint.TryParse(_commands[1], out proposedX))
                return false;

            if (!uint.TryParse(_commands[2], out proposedY))
                return false;

            if (_commands.Length > 3)
            {
                if (!HelperMethods.IsCardinalDirectionValid(_commands[3]))
                    return false;
            }

            if (_commands.Length == 3 && !_toyRobotInstance.IsPlaced)
                return false;

            return true;
        }

        private void SetCoordinates()
        {
            uint proposedX, proposedY = 0;

            uint.TryParse(_commands[1], out proposedX);
            uint.TryParse(_commands[2], out proposedY);

            _toyRobotInstance.SetCoordinates(proposedX, proposedY);
        }

        private void SetCardinalDirection()
        {
            if (_commands.Length > 3 && _commands.Length <= 4
                && Enum.TryParse(_commands[3], true, out CardinalDirection proposedDirection))
            {
                _toyRobotInstance.SetCardinalDirection(proposedDirection);
            }
        }
    }
}