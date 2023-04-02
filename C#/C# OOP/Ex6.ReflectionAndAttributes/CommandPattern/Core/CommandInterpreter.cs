using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = tokens[0];
            string[] cmdArgs = tokens.Skip(1).ToArray();

            Type cmdType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (cmdType == null)
            {
                throw new InvalidOperationException("Command not found!");
            }

            ICommand cmdInstance = Activator.CreateInstance(cmdType) as ICommand;

            return cmdInstance.Execute(cmdArgs);
        }
    }
}
