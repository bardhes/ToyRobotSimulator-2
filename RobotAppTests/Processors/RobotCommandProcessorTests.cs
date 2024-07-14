namespace RobotAppTests.Processors
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;
    using RobotApp.Processors;
    using System.Drawing;

    public class RobotCommandProcessorTests
    {
        private Simulator _simulator;
        private Robot _robot;
        private RobotPosition _startingPosition;

        [SetUp]
        public void Setup()
        {
            _startingPosition = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E);
            _robot = new Robot(_startingPosition);
            _simulator = new Simulator(_robot, new Grid { Dimensions = new Size(4, 3) });
        }

        [TestCase('F')]
        [TestCase('L')]
        [TestCase('R')]
        public void ProcessCommand_ValidCommand_ShouldAlterRobotPosition(char command)
        {
            RobotCommandProcessor.ProcessCommand(_simulator, command);

            Assert.That(_robot.Position, Is.Not.EqualTo(_startingPosition));
        }

        [Test]
        public void ProcessCommand_InvalidCommand_ShouldThrow()
        {
            var invalidCommand = 'B';

            var ex = Assert.Throws<RobotAppException>(() => RobotCommandProcessor.ProcessCommand(_simulator, invalidCommand));

            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.InvalidRobotCommand(invalidCommand)));
        }
    }
}