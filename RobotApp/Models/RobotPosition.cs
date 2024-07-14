namespace RobotApp.Models
{
    using System;
    using RobotApp.Enums;

    public class RobotPosition
    {
        /// <summary>
        /// X-Axis value
        /// </summary>
        public int X { get; init; }

        /// <summary>
        /// Y-Axis value
        /// </summary>
        public int Y { get; init; }

        /// <summary>
        /// Direction the robot is facing
        /// </summary>
        public Orientation Facing { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X-Axis value</param>
        /// <param name="y">Y-Axis value</param>
        /// <param name="facing">Direction the robot is facing</param>
        public RobotPosition(int x, int y, Orientation facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public override bool Equals(object obj)
        {
            return obj is RobotPosition position &&
                   this.X == position.X &&
                   this.Y == position.Y &&
                   this.Facing == position.Facing;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Facing);
        }

        public override string ToString()
        {
            return $"{X} {Y} {Facing}";
        }
    }
}
