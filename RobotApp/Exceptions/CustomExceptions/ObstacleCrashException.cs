namespace RobotApp.Exceptions.CustomExceptions
{
    using System;
    using RobotApp.Models;

    public class ObstacleCrashException : Exception
    {
        public ObstacleCrashException(RobotPosition obstaclePosition) : base($"CRASHED {obstaclePosition.X} {obstaclePosition.Y}")
        {

        }
    }
}
