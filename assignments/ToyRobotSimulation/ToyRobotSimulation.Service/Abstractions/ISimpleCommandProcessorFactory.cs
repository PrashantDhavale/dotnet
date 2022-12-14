using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service
{
    public interface ISimpleCommandProcessorFactory
    {
        ICommandProcessor GetProcessor(CommandType commandType, string[] commands);
    }
}