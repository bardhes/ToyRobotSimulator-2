namespace RobotApp.Mappers
{
    using System;
    using System.Drawing;
    using System.Linq;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Extensions;

    public static class GridSectionMapper
    {
        public static Size Map(string sectionCommand)
        {
            var gridCommandParts = sectionCommand.Split(' ')
                .RemoveEmptyElements()
                .ToList();

            if (gridCommandParts.Count != 2)
            {
                throw new RobotAppException(ExceptionMessages.GridCommandNotInExpectedFormat);
            }

            var gridSizeParts = gridCommandParts[1].Split('x')
                .RemoveEmptyElements()
                .ToList();

            if (gridSizeParts.Count != 2)
            {
                throw new RobotAppException(ExceptionMessages.GridDefinitionNotInExpectedFormat);
            }

            try
            {
                return new Size(int.Parse(gridSizeParts[0]), int.Parse(gridSizeParts[1]));
            }
            catch (Exception ex)
            {
                throw new RobotAppException(ExceptionMessages.GridDefinitionDoesNotHaveExpectedDataTypes, ex);
            }
        }
    }
}
