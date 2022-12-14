using System.Diagnostics;
using ToyRobotSimulation.Service.Abstractions;

namespace ToyRobotSimulation.Service
{
    [DebuggerDisplay("IsPlaced = {IsPlaced} | X = {X} | Y = {Y} | CardinalDirection = {CardinalDirection}")]
    public class ToyRobot : IToyRobot
    {
        #region Members

        private bool _coordinatesAreSet = false;
        private bool _cardinalDirectionIsSet = false;
        public bool IsPlaced
        {
            get
            {
                return _coordinatesAreSet && _cardinalDirectionIsSet;
            }
        }
        public uint X { get; private set; }
        public uint Y { get; private set; }
        public CardinalDirection? CardinalDirection { get; private set; }

        #endregion

        #region Constructor

        public ToyRobot()
        {
            X = Y = 0;
            CardinalDirection = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to set valid coordinates
        /// </summary>
        /// <param name="proposedX">Proposed X coordinate</param>
        /// <param name="proposedY">Proposed Y coordinate</param>
        public void SetCoordinates(uint proposedX, uint proposedY)
        {
            // am I within the bounds?
            if (proposedX <= Constants.MAX_TABLETOP_BOUND && proposedY <= Constants.MAX_TABLETOP_BOUND)
            {
                X = proposedX;
                Y = proposedY;

                _coordinatesAreSet = true;
            }
        }

        /// <summary>
        /// Method to set cardinal direction
        /// </summary>
        /// <param name="proposedCardinalDirection">Proposed CardinalDirection</param>
        public void SetCardinalDirection(CardinalDirection proposedCardinalDirection)
        {
            if (_coordinatesAreSet)
            {
                CardinalDirection = proposedCardinalDirection;
                _cardinalDirectionIsSet = true;
            }
        }

        /// <summary>
        /// Returns a formatted string indicating the ToyRobots current X, Y position and the direction it is facing in
        /// </summary>
        /// <returns>string</returns>
        public string GetReport()
        {
            var report = $"Output: {X},{Y},{CardinalDirection.Value.ToString().ToUpper()}";
            return report;
        }

        #endregion
    }
}