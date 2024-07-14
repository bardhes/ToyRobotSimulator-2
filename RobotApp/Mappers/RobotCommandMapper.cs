namespace RobotApp.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Extensions;

    public static class RobotCommandMapper
    {
        public static IEnumerable<char> Map(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new RobotAppException(ExceptionMessages.RobotCommandIsEmpty);
            }

            var commands = command.ToCharArray();
            if (!commands.All(c => c.IsValidRobotCommand()))
            {
                throw new RobotAppException(ExceptionMessages.RobotCommandContainsUnknownCommands);
            }

            return command.ToCharArray();
        }
    }
}
