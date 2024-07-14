namespace RobotApp.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;

    public static class JourneySectionMapper
    {
        public static Journey Map(IEnumerable<string> journeyCommands)
        {
            if (journeyCommands.Count() != 3)
            {
                throw new RobotAppException(ExceptionMessages.JourneyShouldBeMadeUpOfExactlyThreeLines);
            }

            var commands = journeyCommands.ToList();

            return new Journey
            {
                Start = PositionCommandMapper.Map(commands[0]),
                Commands = RobotCommandMapper.Map(commands[1]),
                End = PositionCommandMapper.Map(commands[2])
            };
        }
    }
}
