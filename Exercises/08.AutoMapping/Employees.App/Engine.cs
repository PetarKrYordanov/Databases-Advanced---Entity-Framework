namespace Employees.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        internal void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string[] commandTokens = input.Split();

                string commandName = commandTokens[0];
                string[] commandArgs = commandTokens.Skip(1).ToArray();

                var command = CommandParser.Parse(serviceProvider, commandName);

                var result = command.Excecute(commandArgs);

                Console.WriteLine(result);
            }
        }
    }
}
