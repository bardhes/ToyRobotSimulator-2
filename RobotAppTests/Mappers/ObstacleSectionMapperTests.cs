namespace RobotApp.Mappers
{
    using System.Drawing;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public class ObstacleSectionMapperTests
    {
        private const int ObstacleSection = 2;

        [Test]
        public void Map_ObstacleSectionIncludesOtherCommands_ThrowsException()
        {
            var sectionGroup = (section: ObstacleSection,
                sectionCommands: new List<string>
            {
                "OBSTACLE",
                "INCLUDES THE WORD OBSTACLE",
                "GRID"
            });

            var ex = Assert.Throws<RobotAppException>(() => ObstacleSectionMapper.Map(sectionGroup));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.ObstacleSectionShouldOnlyContainObstacleCommands));
        }

        [TestCaseSource(nameof(NotThreePartsToThecommandTestCases))]
        public void Map_ObstacleSectionDoesNotHaveExactlyThreeParts_ThrowsException(IEnumerable<string> obstacleCommand)
        {
            var ex = Assert.Throws<RobotAppException>(() => ObstacleSectionMapper.Map((ObstacleSection, obstacleCommand)));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.ObstacleCommandsShouldHaveThreeElements));
        }

        static IEnumerable<IEnumerable<string>> NotThreePartsToThecommandTestCases()
        {
            yield return new List<string> { "OBSTACLE Two" };
            yield return new List<string> { "OBSTACLE Two Three TooMany" };
        }


        [TestCaseSource(nameof(CommandDoesNotParseTestCases))]
        public void Map_ObstacleSectionDoesNotParse_ThrowsException(IEnumerable<string> obstacleCommand)
        {
            var ex = Assert.Throws<RobotAppException>(() => ObstacleSectionMapper.Map((ObstacleSection, obstacleCommand)));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.ObstacleCommandDidNotHaveCorrectDataTypes));
        }

        static IEnumerable<IEnumerable<string>> CommandDoesNotParseTestCases()
        {
            yield return new List<string> { "OBSTACLE 1 2", "OBSTACLE 1 Two" };
            yield return new List<string> { "OBSTACLE One 2" };
            yield return new List<string> { "OBSTACLE 1.1 2" };
            yield return new List<string> { "1 2 OBSTACLE" };
        }

        [TestCaseSource(nameof(CommandParsesCorrectlyTestCases))]
        public void Map_ObstacleSectionThatisCorrectlyConfigured_ShouldParseCorrectly((IEnumerable<string> obstacleCommand, IEnumerable<Point> expectedObstacles) testCase)
        {
            var actual = ObstacleSectionMapper.Map((ObstacleSection, testCase.obstacleCommand));

            Assert.That(actual, Is.EqualTo(testCase.expectedObstacles));
        }

        static IEnumerable<(IEnumerable<string>, IEnumerable<Point>)> CommandParsesCorrectlyTestCases()
        {
            yield return (new List<string> { "OBSTACLE 1 2", "OBSTACLE 3 4" }, new List<Point> { new(1, 2), new(3, 4) });
            yield return (new List<string> { "OBSTACLE 70 40", "OBSTACLE 70 -40" }, new List<Point> { new(70, 40), new(70, -40) });
        }
    }
}
