namespace ToyRobotSimulation.Service.Abstractions
{
    /// <summary>
    /// Contract for all commands
    /// </summary>
    public interface ICommandProcessor
    {
        bool Validate();
        void ProcessMovement();
        string GenerateReport();
    }
}