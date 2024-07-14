namespace RobotApp.Exceptions.CustomExceptions
{
    using System;

    public class RobotAppException : Exception
    {
        public RobotAppException(string message) : base(message)
        {

        }

        public RobotAppException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
