using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service.CommandProcessors
{
    /// <summary>
    /// Base class for common functionality across commands
    /// </summary>
    public abstract class BaseCommandProcessor : ICommandProcessor
    {
        protected string[] _commands;
        protected IToyRobot _toyRobotInstance;

        public BaseCommandProcessor(string[] commands, IToyRobot toyRobot)
        {
            _commands = commands;
            _toyRobotInstance = toyRobot;
        }

        /// <summary>
        /// Overridable method to perform any validations
        /// </summary>
        /// <returns>bool</returns>
        public virtual bool Validate()
        {
            // check if ToyRobot has been placed
            if (!_toyRobotInstance.IsPlaced)
                return false;

            // check the expected command length
            if (_commands.Length != 1)
                return false;

            return true;
        }

        /// <summary>
        /// Overridable movement command processors
        /// </summary>
        public virtual void ProcessMovement()
        {
            return;
        }

        /// <summary>
        /// Overridable reporting command processors
        /// </summary>
        /// <returns>string</returns>
        public virtual string GenerateReport()
        {
            return string.Empty;
        }
    }
}