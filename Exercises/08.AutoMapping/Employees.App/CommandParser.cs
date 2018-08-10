namespace Employees.App
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Employees.App.Command;
    internal class CommandParser
    {
        public static ICommand Parse(IServiceProvider serviceProvider,string commmandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)));

            var commandType = commandTypes.SingleOrDefault(e => e.Name.ToLower() == $"{commmandName.ToLower()}command");

            var constructor = commandType.GetConstructors().FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            var constructorArgs = constructorParams
                .Select(p => serviceProvider.GetService(p))
                .ToArray();

            var command = (ICommand) constructor.Invoke(constructorArgs);

            return command;
        }
    }
}
