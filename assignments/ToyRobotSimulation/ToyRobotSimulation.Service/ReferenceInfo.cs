using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ToyRobotSimulation.Service.Tests")]
namespace ToyRobotSimulation.Service
{
    internal class Constants
    {
        public const uint MAX_TABLETOP_BOUND = 5;
        public const uint MAX_MOVE_PLACES = 1;
    }

    internal class Mappings
    {
        public static readonly Dictionary<string, CardinalDirection> DirectionMapping = new Dictionary<string, CardinalDirection>()
        {
            { $"{CardinalDirection.North}{RelativeDirection.Left}", CardinalDirection.West },
            { $"{CardinalDirection.East}{RelativeDirection.Left}", CardinalDirection.North },
            { $"{CardinalDirection.West}{RelativeDirection.Left}", CardinalDirection.South },
            { $"{CardinalDirection.South}{RelativeDirection.Left}", CardinalDirection.East },
            { $"{CardinalDirection.North}{RelativeDirection.Right}", CardinalDirection.East },
            { $"{CardinalDirection.East}{RelativeDirection.Right}", CardinalDirection.South },
            { $"{CardinalDirection.West}{RelativeDirection.Right}", CardinalDirection.North },
            { $"{CardinalDirection.South}{RelativeDirection.Right}", CardinalDirection.West }
        };
    }

    /// <summary>
    /// Enumeration of all possible cardinal directions. 
    /// </summary>
    public enum CardinalDirection
    {
        North,
        South,
        East,
        West
    }

    /// <summary>
    /// Enumeration of all possible relative directions.
    /// </summary>
    public enum RelativeDirection
    {
        Right,
        Left
    }

    /// <summary>
    /// Enumeration of all possible commands
    /// </summary>
    public enum CommandType
    {
        Place,
        Move,
        Left,
        Right,
        Report
    }
}