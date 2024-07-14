namespace RobotAppTests
{
    using System.Drawing;
    using RobotApp.Enums;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;

    [TestFixture]
    public class SimulatorTests
    {
        private readonly Grid testGrid = new()
        {
            Obstacles = new List<Point> {
                new (0, 2),
                new (2, 2)
            }
        };

        [Test]
        public void Constructor_CreatesTableAndRobot()
        {
            var sut = new Simulator(new Robot(null), testGrid);

            Assert.Multiple(() =>
            {
                Assert.That(sut.MyRobot, Is.Not.Null);
                Assert.That(sut.MyGrid, Is.Not.Null);
            });
        }

        [Test]
        public void Constructor_CreatesDefault5By5Table()
        {
            int expectedWidth = 5;
            int expectedHeight = 5;

            var sut = new Simulator(new Robot(null), testGrid);

            Assert.Multiple(() =>
            {
                Assert.That(sut.MyGrid.Dimensions.Width, Is.EqualTo(expectedWidth));
                Assert.That(sut.MyGrid.Dimensions.Height, Is.EqualTo(expectedHeight));
            });
        }

        [TestCase(0, 3, Orientation.N)]
        [TestCase(3, 4, Orientation.E)]
        [TestCase(4, 1, Orientation.S)]
        [TestCase(1, 0, Orientation.W)]
        public void Move_ValidMove_MovesRobotOn5By5Table(int x, int y, Orientation facing)
        {
            var startingPosition = new RobotPosition(x, y, facing);

            var sut = new Simulator(new Robot(startingPosition), testGrid);

            sut.Move();

            Assert.That(sut.MyRobot.Position, Is.Not.Null);

            var hasMoved = HasMoved(startingPosition, sut.MyRobot.Position);
            Assert.That(hasMoved, Is.True);
        }

        [TestCase(0, 4, Orientation.N)]
        [TestCase(4, 4, Orientation.E)]
        [TestCase(4, 0, Orientation.S)]
        [TestCase(0, 0, Orientation.W)]
        public void Move_InvalidMove_ShouldThrowOutOfBoundsException(int x, int y, Orientation facing)
        {
            var sut = new Simulator(new Robot(new RobotPosition(x, y, facing)), testGrid);

            Assert.Throws<OutOfBoundsException>(() => sut.Move());
        }

        [Test]
        public void Move_HitsObstacle_ShouldThrowObstacleCrashException()
        {
            var sut = new Simulator(new Robot(new RobotPosition(2, 1, Orientation.N)), testGrid);

            Assert.Throws<ObstacleCrashException>(() => sut.Move());
        }

        private static bool HasMoved(RobotPosition currentPosition, RobotPosition expectedPosition)
        {
            return currentPosition.X != expectedPosition.X
                || currentPosition.Y != expectedPosition.Y;
        }
    }
}
