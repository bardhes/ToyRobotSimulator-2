namespace RobotApp.Extensions
{
    using System;
    using RobotApp.Enums;

    static class CharExtension
    {
        public static bool IsValidRobotCommand(this char command)
        {
            return (Enum.TryParse(command.ToString(), out RobotCommandEnum _));
        }
    }
}
