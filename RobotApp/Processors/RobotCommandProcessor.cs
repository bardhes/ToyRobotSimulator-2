using RobotApp.Enums;
using RobotApp.Exceptions;
using RobotApp.Exceptions.CustomExceptions;
using RobotApp.Models;
using System;

namespace RobotApp.Processors
{
    public static class RobotCommandProcessor
    {
        public static void ProcessCommand(Simulator simulator, char command)
        {
            var isValid = Enum.TryParse(command.ToString(), out RobotCommandEnum robotCommand)
                                    && Enum.IsDefined(robotCommand);

            if (!isValid)
            {
                throw new RobotAppException(ExceptionMessages.InvalidRobotCommand(command));
            }

            ProcessCommand(simulator, robotCommand);
        }

        private static void ProcessCommand(Simulator simulator, RobotCommandEnum command)
        {
            switch (command)
            {
                case RobotCommandEnum.F:
                    simulator.Move();
                    break;
                case RobotCommandEnum.L:
                    simulator.Left();
                    break;
                case RobotCommandEnum.R:
                    simulator.Right();
                    break;
            }
        }
    }
}