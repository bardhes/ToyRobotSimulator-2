namespace RobotApp.Models
{
    using RobotApp.Enums;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public class Robot
    {
        /// <summary>
        /// Position of the robot on the table
        /// </summary>
        public RobotPosition Position { get; private set; }

        /// <summary>
        /// Places the robot on the grid.
        /// </summary>
        public Robot(RobotPosition startingPosition)
        {
            Position = startingPosition;
        }

        /// <summary>
        /// Turn the robot 90 degrees to the left
        /// </summary>
        public void TurnLeft()
        {
            if (Position != null)
            {
                try
                {
                    Turn(Enums.Turn.LEFT);
                }
                catch
                {
                    // Do nothing when an exception occurs
                }
            }
        }

        /// <summary>
        /// Turn the robot 90 degrees to the right
        /// </summary>
        /// <param name="facing">The current direction - <see cref="Orientation"/></param>
        public void TurnRight()
        {
            if (Position != null)
            {
                try
                {
                    Turn(Enums.Turn.RIGHT);
                }
                catch
                {
                    // Do nothing when an exception occurs
                }
            }
        }

        /// <summary>
        /// Moves the robot one unit in the direction it is facing.
        /// </summary>
        public void Move()
        {
            if (Position != null)
            {
                var currentPosition = Position;

                switch (Position.Facing)
                {
                    case Orientation.N:
                        Position = new RobotPosition(currentPosition.X, currentPosition.Y + 1, currentPosition.Facing);
                        break;
                    case Orientation.E:
                        Position = new RobotPosition(currentPosition.X + 1, currentPosition.Y, currentPosition.Facing);
                        break;
                    case Orientation.S:
                        Position = new RobotPosition(currentPosition.X, currentPosition.Y - 1, currentPosition.Facing);
                        break;
                    case Orientation.W:
                        Position = new RobotPosition(currentPosition.X - 1, currentPosition.Y, currentPosition.Facing);
                        break;
                }
            }
        }

        /// <summary>
        /// Reports the robot's position on the table
        /// </summary>
        /// <returns>A string representing the robot's x,y co-ordinates and the direction it's facing.</returns>
        public string Report()
        {
            if (Position != null)
            {
                return $"{Position.X} {Position.Y} {Position.Facing}";
            }

            return string.Empty;
        }

        /// <summary>
        /// Turn the robot on the table.
        /// </summary>
        /// <param name="facing">The current direction - <see cref="Orientation"/></param>
        /// <param name="direction">The direction to turn - <see cref="Models.Turn"/> </param>
        /// <exception cref="RobotAppException">Thrown if the current orientation isn't supported.</exception>
        private void Turn(Turn direction)
        {
            if (Position != null)
            {
                var currentPosition = Position;
                Orientation? newOrientation = null;
                switch (Position.Facing)
                {
                    case Orientation.N:
                        newOrientation = Enums.Turn.RIGHT == direction ? Orientation.E : Orientation.W;
                        break;
                    case Orientation.E:
                        newOrientation = Enums.Turn.RIGHT == direction ? Orientation.S : Orientation.N;
                        break;
                    case Orientation.S:
                        newOrientation = Enums.Turn.RIGHT == direction ? Orientation.W : Orientation.E;
                        break;
                    case Orientation.W:
                        newOrientation = Enums.Turn.RIGHT == direction ? Orientation.N : Orientation.S;
                        break;
                }

                if (newOrientation == null)
                {
                    throw new RobotAppException(ExceptionMessages.RobotPositionOrientationNotSupportedForTurn(Position.Facing));
                }

                Position = new RobotPosition(currentPosition.X, currentPosition.Y, newOrientation.Value);
            }
        }
    }
}
