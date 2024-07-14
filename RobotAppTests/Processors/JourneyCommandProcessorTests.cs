namespace RobotAppTests.Processors
{
    using RobotApp.Models;
    using RobotApp.Processors;
    using System.Drawing;

    public class JourneyCommandProcessorTests
    {
        [Test]
        public void ProcessJourneyCommands_WhenStartIsOutOfBounds_ShouldCatchException()
        {
            var actual = JourneyCommandProcessor.ProcessJourneyCommands(
                new Grid { Dimensions = new Size(2, 2), },
                new Journey
                {
                    Start = new RobotPosition(2, 1, RobotApp.Enums.Orientation.N)
                });

            Assert.That(actual, Is.EqualTo("OUT OF BOUNDS"));
        }

        [Test]
        public void ProcessJourneyCommands_WhenStartIsObstacle_ShouldCatchException()
        {
            var actual = JourneyCommandProcessor.ProcessJourneyCommands(
                new Grid
                {
                    Dimensions = new Size(2, 2),
                    Obstacles = new List<Point> { new Point(1, 1) }
                },
                new Journey
                {
                    Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.N)
                });

            Assert.That(actual, Is.EqualTo("CRASHED 1 1"));
        }

        [Test]
        public void ProcessJourneyCommands_WhenEndPositionMatches_ShouldReturnSuccessMessage()
        {
            var actual = JourneyCommandProcessor.ProcessJourneyCommands(
                new Grid
                {
                    Dimensions = new Size(4, 3),
                },
                new Journey
                {
                    Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                    End = new RobotPosition(1, 0, RobotApp.Enums.Orientation.W),
                    Commands = new List<char> { 'R', 'F', 'R' }
                });

            Assert.That(actual, Is.EqualTo("SUCCESS 1 0 W"));
        }

        [Test]
        public void ProcessJourneyCommands_WhenEndPositionDoesNotMatch_ShouldReturnFailureMessage()
        {
            var actual = JourneyCommandProcessor.ProcessJourneyCommands(
                new Grid
                {
                    Dimensions = new Size(4, 3),
                },
                new Journey
                {
                    Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                    End = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                    Commands = new List<char> { 'R', 'F', 'R', 'F' }
                });

            Assert.That(actual, Is.EqualTo("FAILURE 0 0 W"));
        }

        [Test]
        public void ProcessJourneyCommands_WhenRobotIsOutOfBoundsDuringJourney_ShouldReturnOutOfBoundsMessage()
        {
            var actual = JourneyCommandProcessor.ProcessJourneyCommands(
                new Grid
                {
                    Dimensions = new Size(4, 3),
                },
                new Journey
                {
                    Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                    End = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                    Commands = new List<char> { 'R', 'F', 'F' }
                });

            Assert.That(actual, Is.EqualTo("OUT OF BOUNDS"));
        }
    }
}