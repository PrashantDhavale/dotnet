using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service.CommandProcessors
{
    public class ReportCommandProcessor : BaseCommandProcessor
    {
        public ReportCommandProcessor(string[] commands, IToyRobot toyRobot) : base(commands, toyRobot)
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
            if (commandType != CommandType.Report)
                return false;

            return true;
        }

        public override string GenerateReport()
        {
            bool isValid = Validate();
            if (!isValid)
                return string.Empty;

            return _toyRobotInstance.GetReport();
        }
    }
}