using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;
using ToyRobotSimulation.Service.CommandProcessors;

namespace ToyRobotSimulation.Client
{
    public class SimpleCommandProcessorFactory : ISimpleCommandProcessorFactory
    {
        private IToyRobot _toyRobot;

        public SimpleCommandProcessorFactory(IToyRobot toyRobot)
        {
            _toyRobot = toyRobot;
        }

        public ICommandProcessor GetProcessor(CommandType commandType, string[] commands)
        {
            ICommandProcessor commandProcessor = null;

            switch (commandType)
            {
                case CommandType.Place:
                    commandProcessor = new PlaceCommandProcessor(commands, _toyRobot);
                    break;
                case CommandType.Move:
                    commandProcessor = new MoveCommandProcessor(commands, _toyRobot);
                    break;
                case CommandType.Left:
                    commandProcessor = new LeftCommandProcessor(commands, _toyRobot);
                    break;
                case CommandType.Right:
                    commandProcessor = new RightCommandProcessor(commands, _toyRobot);
                    break;
                case CommandType.Report:
                    commandProcessor = new ReportCommandProcessor(commands, _toyRobot);
                    break;

                default:
                    break;
            }

            return commandProcessor;
        }
    }
}