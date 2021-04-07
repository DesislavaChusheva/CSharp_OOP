using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CommandPattern.Core.Contracts
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandSuffix = "Command";
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly()
                               .GetTypes()
                               .FirstOrDefault(t => t.Name == $"{commandType}{CommandSuffix}");
            if (type == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type.");
            }
            ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
