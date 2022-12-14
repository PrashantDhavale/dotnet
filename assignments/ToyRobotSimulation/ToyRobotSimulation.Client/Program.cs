using System;
using ToyRobotSimulation.Service;
using ToyRobotSimulation.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ToyRobotSimulation.Client
{
    class Program
    {
        private static ISimpleCommandProcessorFactory _simpleCommandProcessorFactory;
        public static void Main(string[] args)
        {
            try
            {
                //setup our DI
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<ISimpleCommandProcessorFactory, SimpleCommandProcessorFactory>()
                    .AddSingleton<IToyRobot, ToyRobot>()
                    .BuildServiceProvider();

                _simpleCommandProcessorFactory = serviceProvider.GetService<ISimpleCommandProcessorFactory>();

                DisplayHeader();
                HandleUserInput();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }

        private static void DisplayHeader()
        {
            Console.WriteLine("-------------------------ToyRobot Simulation-------------------------\n");
        }

        /// <summary>
        /// Method to handle user input
        /// </summary>
        private static void HandleUserInput()
        {
            do
            {
                // read the user input string, trim it and convert to upper case before using
                var userInput = Console.ReadLine().Trim().ToUpper();

                // split the user input and store in an array
                var commands = userInput.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // length guard
                if (commands.Length == 0)
                {
                    // user is hitting enter with no option specified
                    // continue the loop (not a requirement - supporting for a better user experience)
                    continue;
                }

                var commandType = HelperMethods.EvaluateCommandType(commands);

                if (!commandType.HasValue)
                {
                    // invalid or unknown command keyed in
                    continue;
                }

                // process commands
                HandleCommands(commandType.Value, commands);
            }
            while (true);
        }

        /// <summary>
        /// Method to handle all commands
        /// </summary>
        /// <param name="commandType">Evaluated command type</param>
        /// <param name="commands">String array of user command</param>
        private static void HandleCommands(CommandType commandType, string[] commands)
        {
            // Get movement command processor
            ICommandProcessor commandProcessor = _simpleCommandProcessorFactory.GetProcessor(commandType, commands);
            if (commandProcessor == null)
                return;

            if (commandType == CommandType.Report)
            {
                // Process the report command
                string report = commandProcessor.GenerateReport();

                // Print report
                if (!string.IsNullOrEmpty(report))
                    Console.WriteLine(report);
            }
            else
            {
                // Process the movement command
                commandProcessor.ProcessMovement();
            }
        }
    }
}