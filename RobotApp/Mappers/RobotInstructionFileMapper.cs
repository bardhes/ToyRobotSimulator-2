namespace RobotApp.Mappers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using RobotApp.Models;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public static class RobotInstructionFileMapper
    {
        public static RobotInstructionFile Map(IEnumerable<string> lines)
        {
            ValidateFileIsNotEmpty(lines);

            List<(int section, string line)> fileSections = GetFileSections(lines);

            ValidateFileHasAtLeastOneSection(fileSections);

            var commandSections = fileSections
                .GroupBy(s => s.section)
                .Select(g => (g.Key, lines: g.Select(gv => gv.line)));

            ValidateGridDefinitionIsFirstSection(commandSections);

            return MapProcessedFile(commandSections);
        }

        private static void ValidateGridDefinitionIsFirstSection(IEnumerable<(int Key, IEnumerable<string> lines)> commandSections)
        {
            if (!commandSections.First().lines.First().Contains("GRID"))
            {
                throw new RobotAppException(ExceptionMessages.GridDefinitionMustBeFirst);
            }
        }

        private static void ValidateFileHasAtLeastOneSection(List<(int section, string line)> fileSections)
        {
            if (fileSections.Count == 0)
            {
                throw new RobotAppException(ExceptionMessages.FileFullOfEmptyLines);
            }
        }

        private static void ValidateFileIsNotEmpty(IEnumerable<string> lines)
        {
            if (lines == null || !lines.Any())
            {
                throw new RobotAppException(ExceptionMessages.FileIsEmpty);
            }
        }

        private static RobotInstructionFile MapProcessedFile(IEnumerable<(int key, IEnumerable<string> lines)> fileSections)
        {
            Size grid = new Size();
            var obstacles = new List<Point>();
            var journeys = new List<Journey>();

            foreach (var section in fileSections)
            {
                var sectionCommands = section.lines.ToList();

                if (sectionCommands.Any(c => c.Contains("GRID")))
                {
                    grid = MapGrid(section);
                    continue;
                }

                if (sectionCommands.Any(c => c.Contains("OBSTACLE")))
                {
                    obstacles = MapObstacles(section);
                    continue;
                }

                journeys.Add(MapJourney(sectionCommands));
            }

            return new RobotInstructionFile
            {
                GridDimensions = grid,
                Obstacles = obstacles,
                Journeys = journeys
            };
        }

        private static List<Point> MapObstacles((int section, IEnumerable<string> line) sectionGroup)
        {
            List<Point> obstacles;
            if (sectionGroup.section != 2)
            {
                throw new RobotAppException(ExceptionMessages.ObstacleSectionShouldBeAfterGridSection);
            }

            obstacles = ObstacleSectionMapper.Map(sectionGroup).ToList();
            return obstacles;
        }

        private static Size MapGrid((int section, IEnumerable<string> lines) sectionGroup)
        {
            if (sectionGroup.lines.Count() > 1)
            {
                throw new RobotAppException(ExceptionMessages.GridMustOnlyBeDefinedOnce);
            }

            if (sectionGroup.section != 1)
            {
                throw new RobotAppException(ExceptionMessages.GridDefinitionMustBeFirstAndOnlyOne);
            }

            var grid = GridSectionMapper.Map(sectionGroup.lines.First());
            return grid;
        }

        private static Journey MapJourney(IEnumerable<string> sectionCommands)
        {
            return JourneySectionMapper.Map(sectionCommands);
        }

        private static List<(int section, string line)> GetFileSections(IEnumerable<string> lines)
        {
            var fileSections = new List<(int section, string line)>();
            var section = 1;

            foreach (string line in lines)
            {
                if (line.Trim().Length > 0)
                {
                    fileSections.Add((section, line));
                    continue;
                }

                if (fileSections.Any(s => s.section == section))
                {
                    section++;
                }
            }

            return fileSections;
        }
    }
}
