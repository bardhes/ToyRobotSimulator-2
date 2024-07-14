namespace RobotAppTests
{
    using RobotApp.Enums;
    using RobotApp.Models;

    [TestFixture]
    public class RobotTests
    {
        [Test]
        public void Move_WhenRobotHasNotBeenPlaced_PositionIsNull()
        {
            var sut = new Robot(null);
            sut.Move();

            Assert.That(sut.Position, Is.Null);
        }

        [TestCaseSource(nameof(MoveTestCases))]
        public void Move_WhenRobotHasBeenPlaced_RobotPositionIsAsExpected((RobotPosition startingPoint, RobotPosition expectedFollowingMove) testCase)
        {
            var sut = new Robot(testCase.startingPoint);

            sut.Move();

            Assert.That(sut.Position, Is.EqualTo(testCase.expectedFollowingMove));
        }

        static IEnumerable<(RobotPosition startingPoint, RobotPosition expectedFollowingMove)> MoveTestCases()
        {
            yield return (new RobotPosition(0, 0, Orientation.N), new RobotPosition(0, 1, Orientation.N));
            yield return (new RobotPosition(0, 0, Orientation.S), new RobotPosition(0, -1, Orientation.S));
            yield return (new RobotPosition(0, 0, Orientation.E), new RobotPosition(1, 0, Orientation.E));
            yield return (new RobotPosition(0, 0, Orientation.W), new RobotPosition(-1, 0, Orientation.W));
            yield return (new RobotPosition(4, 4, Orientation.N), new RobotPosition(4, 5, Orientation.N));
            yield return (new RobotPosition(4, 4, Orientation.S), new RobotPosition(4, 3, Orientation.S));
            yield return (new RobotPosition(4, 4, Orientation.E), new RobotPosition(5, 4, Orientation.E));
            yield return (new RobotPosition(4, 4, Orientation.W), new RobotPosition(3, 4, Orientation.W));
        }

        [Test]
        public void TurnLeft_WhenRobotHasNotBeenPlaced_PositionIsNull()
        {
            var sut = new Robot(null);
            sut!.TurnLeft();

            Assert.That(sut.Position, Is.Null);
        }

        [TestCase(0, 0)]
        [TestCase(4, 4)]
        [TestCase(0, 4)]
        [TestCase(4, 0)]
        public void TurnLeft_WhenRobotHasBeenPlaced_RobotPositionDoesNotChange(int x, int y)
        {
            var sut = new Robot(new RobotPosition(x, y, Orientation.W));

            sut.TurnLeft();

            Assert.Multiple(() =>
            {
                Assert.That(sut.Position.X, Is.EqualTo(x));
                Assert.That(sut.Position.Y, Is.EqualTo(y));
            });
        }

        [TestCase(Orientation.N, ExpectedResult = Orientation.W)]
        [TestCase(Orientation.S, ExpectedResult = Orientation.E)]
        [TestCase(Orientation.E, ExpectedResult = Orientation.N)]
        [TestCase(Orientation.W, ExpectedResult = Orientation.S)]
        public Orientation TurnLeft_WhenRobotHasBeenPlaced_RobotDirectionIsCorrectlyChanged(Orientation startingDirection)
        {
            var sut = new Robot(new RobotPosition(0, 0, startingDirection));

            sut.TurnLeft();

            return sut.Position.Facing;
        }

        [Test]
        public void TurnRight_WhenRobotHasNotBeenPlaced_PositionIsNull()
        {
            var sut = new Robot(null);
            sut!.TurnRight();

            Assert.That(sut.Position, Is.Null);
        }

        [TestCase(Orientation.N, ExpectedResult = Orientation.E)]
        [TestCase(Orientation.S, ExpectedResult = Orientation.W)]
        [TestCase(Orientation.E, ExpectedResult = Orientation.S)]
        [TestCase(Orientation.W, ExpectedResult = Orientation.N)]
        public Orientation TurnRight_WhenRobotHasBeenPlaced_RobotDirectionIsCorrectlyChanged(Orientation startingDirection)
        {
            var sut = new Robot(new RobotPosition(0, 0, startingDirection));

            sut.TurnRight();

            return sut.Position.Facing;
        }

        [Test]
        public void Report_WhenRobotHasNotBeenPlaced_ReturnsEmptyString()
        {
            var sut = new Robot(null);
            string actual = sut.Report();

            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void Report_WhenRobotHasBeenPlaced_ReturnsExpectedString()
        {
            var sut = new Robot(new RobotPosition(0, 0, Orientation.N));
            string expected = $"0 0 N";

            string actual = sut.Report();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
