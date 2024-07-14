namespace RobotApp.Models
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Grid
    {
        /// <summary>
        /// Dimensions of the grid.
        /// Grid dimensions are defaulted to 5 by 5.
        /// </summary>
        public Size Dimensions { get; init; } = new Size(5, 5);

        /// <summary>
        /// Optional obstacles to add to the grid.
        /// NB: Obstacle detail are not validated to ensure they are within the grid dimensions.
        /// </summary>
        public IEnumerable<Point> Obstacles { get; init; } = Enumerable.Empty<Point>();

        /// <summary>
        /// Max zero based index of x
        /// </summary>
        public int MaxX => Dimensions.Width - 1;

        /// <summary>
        /// Max zero based index of y
        /// </summary>
        public int MaxY => Dimensions.Height - 1;


        /// <summary>
        /// Grid constructor.
        /// </summary>
        public Grid() { }
    }
}
