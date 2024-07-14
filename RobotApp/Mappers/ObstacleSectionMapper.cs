namespace RobotApp.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public static class ObstacleSectionMapper
    {
        public static IEnumerable<Point> Map((int section, IEnumerable<string> sectionCommands) sectionGroup)
        {
            if (sectionGroup.sectionCommands.Any(c => !c.Contains("OBSTACLE")))
            {
                throw new RobotAppException(ExceptionMessages.ObstacleSectionShouldOnlyContainObstacleCommands);
            }

            var obstacleCommandParts = sectionGroup.sectionCommands.Select(c => c.Split(' ')).ToList();

            if (obstacleCommandParts.Any(c => c.Length != 3))
            {
                throw new RobotAppException(ExceptionMessages.ObstacleCommandsShouldHaveThreeElements);
            }

            try
            {
                return obstacleCommandParts.Select(c =>
                {
                    var validX = int.TryParse(c[1], out int x);
                    var validY = int.TryParse(c[2], out int y);

                    if (validX && validY)
                    {
                        return new Point(x, y);
                    }

                    throw new RobotAppException(ExceptionMessages.ObstacleCommandDidNotHaveCorrectDataTypes);
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new RobotAppException(ExceptionMessages.ObstacleCommandDidNotHaveCorrectDataTypes, ex);
            }
        }
    }
}
