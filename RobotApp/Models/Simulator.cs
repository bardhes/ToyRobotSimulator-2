namespace RobotApp.Models
{
    using System.Linq;
    using RobotApp.Exceptions.CustomExceptions;

    public class Simulator
    {
        /// <summary>
        /// Instance of the robot
        /// </summary>
        public Robot MyRobot { get; init; }

        /// <summary>
        /// Instance ofthe table
        /// </summary>
        public Grid MyGrid { get; init; }

        /// <summary>
        /// Constructor creates new instance of <see cref="MyRobot"/> and <see cref="MyGrid"/>
        /// </summary>
        public Simulator(Robot robot, Grid grid)
        {
            MyRobot = robot;
            MyGrid = grid;

            ValidateRobotPosition(MyRobot.Position);
        }

        /// <summary>
        /// Moves the robot one unit in the direction it is facing.
        /// </summary>
        /// <exception cref="OutOfBoundsException">Thrown when the robot is moved or placed in a position outside of the grid.</exception>
        /// <exception cref="ObstacleCrashException">Thrown when the robot is moved into a position occupied by an obstacle.</exception>
        public void Move()
        {
            MyRobot.Move();

            ValidateRobotPosition(MyRobot.Position);
        }

        private void ValidateRobotPosition(RobotPosition newPosition)
        {
            if (newPosition == null)
            {
                return;
            }

            if (newPosition.X > MyGrid.MaxX || newPosition.X < 0 ||
                            newPosition.Y > MyGrid.MaxY || newPosition.Y < 0)
            {
                throw new OutOfBoundsException();
            }

            if (MyGrid.Obstacles.ToList().Any(o => o.X == newPosition.X && o.Y == newPosition.Y))
            {
                throw new ObstacleCrashException(newPosition);
            }
        }

        /// <summary>
        /// Turns the robot 90 degrees to the left
        /// </summary>
        public void Left() => MyRobot.TurnLeft();

        /// <summary>
        /// Turns the robot 90 degrees to the right
        /// </summary>
        public void Right() => MyRobot.TurnRight();

        /// <summary>
        /// Reports the robot's x,y co-ordinates and the direction it's facing
        /// </summary>
        public string Report() => MyRobot.Report();
    }
}
