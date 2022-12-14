namespace ToyRobotSimulation.Service.Abstractions
{
    public interface IToyRobot
    {
        CardinalDirection? CardinalDirection { get; }
        bool IsPlaced { get; }
        uint X { get; }
        uint Y { get; }

        string GetReport();
        void SetCardinalDirection(CardinalDirection proposedCardinalDirection);
        void SetCoordinates(uint proposedX, uint proposedY);
    }
}