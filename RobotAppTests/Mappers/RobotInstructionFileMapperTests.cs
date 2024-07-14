namespace RobotApp.Mappers
{
    using System.Drawing;
    using RobotApp.Enums;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;

    public class RobotInstructionFileMapperTests
    {
        [TestCaseSource(nameof(EmptyFileTestCases))]
        public void Map_RobotInstructionFileIsEmpty_ThrowsException(IEnumerable<string> lines)
        {
            var ex = Assert.Throws<RobotAppException>(() => RobotInstructionFileMapper.Map(lines));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.FileIsEmpty));
        }

        static IEnumerable<IEnumerable<string>> EmptyFileTestCases()
        {
            yield return null!;
            yield return Array.Empty<string>();
        }

        [Test]
        public void Map_RobotInstructionFileOnLyContainsEmptyLines_ThrowsException()
        {
            var lines = new List<string> { string.Empty, string.Empty, string.Empty };
            var ex = Assert.Throws<RobotAppException>(() => RobotInstructionFileMapper.Map(lines));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.FileFullOfEmptyLines));
        }

        [Test]
        public void Map_RobotInstructionFileContainsMoreThanOneGridCommandInFirstSection_ThrowsException()
        {
            var lines = new List<string> { "GRID 10x10", "GRID 20x20" };
            var ex = Assert.Throws<RobotAppException>(() => RobotInstructionFileMapper.Map(lines));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridMustOnlyBeDefinedOnce));
        }

        [Test]
        public void Map_RobotInstructionFileDoesNotBeginWithGridSection_ThrowsException()
        {
            var lines = new List<string> { "1 1 E", "RFRFRFRF", "1 1 E", string.Empty, "GRID 20x20" };
            var ex = Assert.Throws<RobotAppException>(() => RobotInstructionFileMapper.Map(lines));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridDefinitionMustBeFirst));
        }

        [Test]
        public void Map_RobotInstructionFileContainsMultipleGridSections_ThrowsException()
        {
            var lines = new List<string> { "GRID 10x10", string.Empty, "GRID 20x20" };
            var ex = Assert.Throws<RobotAppException>(() => RobotInstructionFileMapper.Map(lines));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridDefinitionMustBeFirstAndOnlyOne));
        }

        [Test]
        public void Map_RobotInstructionFileDefinesObstacleSectionAheadOfGridSection_ThrowsException()
        {
            var lines = new List<string> { "OBSTACLE", string.Empty, "GRID 20x20" };
            var ex = Assert.Throws<RobotAppException>(() => RobotInstructionFileMapper.Map(lines));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridDefinitionMustBeFirst));
        }

        [Test]
        public void Map_RobotInstructionFileDefinesObstacleSectionAfterFirstJourney_ThrowsException()
        {
            var lines = new List<string>
            {
                "GRID 20x20",
                string.Empty,
                 "1 1 E", "RFRFRFRF", "1 1 E",
                string.Empty,
                "OBSTACLE"
            };

            var ex = Assert.Throws<RobotAppException>(() => RobotInstructionFileMapper.Map(lines));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.ObstacleSectionShouldBeAfterGridSection));
        }

        [Test]
        public void Map_RobotInstructionFileWithObstaclesThatIsCorrectlyFormatted_ShouldMapCorrectly()
        {
            var lines = new List<string>
            {
                string.Empty,
                "GRID 20x20",
                string.Empty,
                "OBSTACLE 1 2",
                "OBSTACLE 3 4",
                string.Empty,
                "1 1 E", "RFRFRFRF", "1 1 E",
                string.Empty,
                "3 2 N", "FRRFLLFFRRFLL", "3 3 N"
            };

            var expectedFile = new RobotInstructionFile
            {
                GridDimensions = new Size(20, 20),
                Obstacles = new List<Point> { new(1, 2), new(3, 4) },
                Journeys = new List<Journey>
                {
                    new ()
                    {
                        Start = new RobotPosition(1, 1, Orientation.E),
                        Commands = "RFRFRFRF".ToCharArray(),
                        End = new RobotPosition(1, 1, Orientation.E)
                    },
                    new ()
                    {
                        Start = new RobotPosition(3, 2, Orientation.N),
                        Commands = "FRRFLLFFRRFLL".ToCharArray(),
                        End = new RobotPosition(3, 3, Orientation.N)
                    }
                }
            };

            var actual = RobotInstructionFileMapper.Map(lines);

            Assert.Multiple(() =>
            {
                Assert.That(actual.GridDimensions, Is.EqualTo(expectedFile.GridDimensions));
                Assert.That(actual.Obstacles, Is.EquivalentTo(expectedFile.Obstacles));

                var actualJourneys = actual.Journeys.ToList();
                var expectedJourneys = expectedFile.Journeys.ToList();

                AssertJourney(actualJourneys[0], expectedJourneys[0]);
                AssertJourney(actualJourneys[1], expectedJourneys[1]);
            });

        }

        [Test]
        public void Map_RobotInstructionFileWithoutObstaclesThatIsCorrectlyFormatted_ShouldMapCorrectly()
        {
            var lines = new List<string>
            {
                string.Empty,
                "GRID 20x20",
                string.Empty,
                "1 1 E", "RFRFRF", "1 1 W",
                string.Empty,
            };

            var expectedFile = new RobotInstructionFile
            {
                GridDimensions = new Size(20, 20),
                Obstacles = Enumerable.Empty<Point>(),
                Journeys = new List<Journey>
                {
                    new ()
                    {
                        Start = new RobotPosition(1, 1, Orientation.E),
                        Commands = "RFRFRF".ToCharArray(),
                        End = new RobotPosition(1, 1, Orientation.W)
                    }
                }
            };

            var actual = RobotInstructionFileMapper.Map(lines);

            Assert.Multiple(() =>
            {
                Assert.That(actual.GridDimensions, Is.EqualTo(expectedFile.GridDimensions));
                Assert.That(actual.Obstacles, Is.EquivalentTo(expectedFile.Obstacles));

                var actualJourneys = actual.Journeys.ToList();
                var expectedJourneys = expectedFile.Journeys.ToList();

                AssertJourney(actualJourneys[0], expectedJourneys[0]);
            });

        }

        private static void AssertJourney(Journey actual, Journey expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.Start, Is.EqualTo(expected.Start));
                Assert.That(actual.End, Is.EqualTo(expected.End));
                Assert.That(actual.Commands, Is.EqualTo(expected.Commands));
            });
        }
    }
}
