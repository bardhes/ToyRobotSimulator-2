using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RobotApp.Models
{
    /// <summary>
    /// Defines the structure of a robot instruction file
    /// </summary>
    public class RobotInstructionFile
    {
        /// <summary>
        /// Size of the grid the robot operates on.
        /// Default is 5x5.
        /// </summary>
        public Size GridDimensions { get; init; } = new Size(5, 5);

        /// <summary>
        /// Optional collection of obstacles on the grid.
        /// </summary>
        public IEnumerable<Point> Obstacles { get; init; } = Enumerable.Empty<Point>();

        /// <summary>
        /// Collection of one or more journeys the robot will undertake.
        /// </summary>
        public IEnumerable<Journey> Journeys { get; init; } = Enumerable.Empty<Journey>();

        /// <summary>
        /// Constructor
        /// </summary>
        public RobotInstructionFile() { }
    }
}
