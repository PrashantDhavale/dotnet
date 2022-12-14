using System;

namespace ToyRobotSimulation.Service
{
    public sealed class HelperMethods
    {
        /// <summary>
        /// Method to validate if the given user input has a valid cardinal direction
        /// </summary>
        /// <param name="userInputValue">string cardinal direction</param>
        /// <returns>bool</returns>
        public static bool IsCardinalDirectionValid(string userInputValue)
        {
            var cardinalDirectionNames = Enum.GetNames(typeof(CardinalDirection));

            bool isCardinalDirectionDefined = false;

            foreach (string cardinalDirectionName in cardinalDirectionNames)
            {
                if (string.Compare(cardinalDirectionName, userInputValue, true) == 0)
                {
                    isCardinalDirectionDefined = true;
                    break;
                }
            }

            return isCardinalDirectionDefined;
        }

        /// <summary>
        /// Method to validate if the given user input has a valid command type
        /// </summary>
        /// <param name="userInputValue">string command type</param>
        /// <returns>bool</returns>
        public static bool IsCommandTypeValid(string userInputValue)
        {
            var commandTypes = Enum.GetNames(typeof(CommandType));

            bool isCommandTypeDefined = false;

            foreach (string commandType in commandTypes)
            {
                if (string.Compare(commandType, userInputValue, true) == 0)
                {
                    isCommandTypeDefined = true;
                    break;
                }
            }

            return isCommandTypeDefined;
        }

        /// <summary>
        /// Helper method to validate and evaluate command type enumerator
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        public static CommandType? EvaluateCommandType(string[] commands)
        {
            if (commands.Length == 0)
                throw new ArgumentException("Empty command");

            if (!IsCommandTypeValid(commands[0]))
                return null;

            Enum.TryParse(commands[0], true, out CommandType evaluatedCommandType);

            return evaluatedCommandType;
        }
    }
}