namespace RobotApp.Models
{
    using System.Collections.Generic;
    using RobotApp.Enums;

    /// <summary>
    /// Journey details.
    /// </summary>
    public class Journey
    {
        /// <summary>
        /// The starting position of the robot.
        /// </summary>
        public RobotPosition Start { get; init; }

        /// <summary>
        /// The commands the robot will execute. Must be one of <see cref="RobotCommandEnum"/>
        /// </summary>
        public IEnumerable<char> Commands { get; init; }

        /// <summary>
        /// Expected end position of the robot.
        /// </summary>
        public RobotPosition End { get; init; }


        /// <summary>
        /// Journey constructor.
        /// </summary>
        public Journey() { }
    }
}
