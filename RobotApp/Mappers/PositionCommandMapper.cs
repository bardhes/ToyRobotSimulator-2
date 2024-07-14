namespace RobotApp.Mappers
{
    using System;
    using RobotApp.Enums;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;

    public static class PositionCommandMapper
    {
        public static RobotPosition Map(string command)
        {
            var commandSegments = command.Split(" ");

            if (commandSegments.Length != 3)
            {
                throw new RobotAppException(ExceptionMessages.RobotPositionCommandDoesNotHaveCorrectNumberOfElements);
            }

            var validOrientation = Enum.TryParse(commandSegments[2], out Orientation theParsedOrientation)
                && Enum.IsDefined(typeof(Orientation), theParsedOrientation);

            if (!validOrientation)
            {
                throw new RobotAppException(ExceptionMessages.RobotPositionCommandDoesNotHaveValidOrientation);
            }

            try
            {
                return new RobotPosition(int.Parse(commandSegments[0]), int.Parse(commandSegments[1]), Enum.Parse<Orientation>(commandSegments[2]));
            }
            catch (Exception ex)
            {
                throw new RobotAppException(ExceptionMessages.RobotPositionCommandDoesNotHaveCorrectDataTypes, ex);
            }
        }
    }
}
