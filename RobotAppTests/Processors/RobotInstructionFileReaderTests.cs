namespace RobotAppTests.Processors
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;
    using RobotApp.Processors;

    public class RobotInstructionFileReaderTests
    {
        [Test]
        public void Read_FileDoesNotExist_Throws()
        {
            var sut = new RobotInstructionFileReader("nonexistent.txt");
            var ex = Assert.Throws<RobotAppException>(() => sut.Read());

            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.FileReadProblem("nonexistent.txt")));
        }

        [Test]
        public void Read_FileIsNotTxt_Throws()
        {
            var sut = new RobotInstructionFileReader("nonexistent.doc");
            var ex = Assert.Throws<RobotAppException>(() => sut.Read());

            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.FileExtensionInvalid("nonexistent.doc")));
        }

        [Test]
        public void Read_FileIsNotValidRobotInstructionFile_Throws()
        {
            var sut = new RobotInstructionFileReader(Path.Combine("TestCommandFiles", "InvalidSample.txt"));
            var ex = Assert.Throws<RobotAppException>(() => sut.Read());

            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridDefinitionMustBeFirst));
        }

        [Test]
        public void Read_FileIsValidRobotInstructionFile_ShouldReturnMappedFileObject()
        {
            var expected = new RobotInstructionFile
            {
                GridDimensions = new System.Drawing.Size(40, 40),
                Obstacles = new List<System.Drawing.Point>
                {
                    new System.Drawing.Point(1, 2),
                    new System.Drawing.Point(1, 3),
                },
                Journeys = new List<Journey>
                {
                    new ()
                    {
                        Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                        End = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                        Commands = new List<char> { 'R', 'F', 'R', 'F', 'R', 'F', 'R', 'F' }
                    },
                    new ()
                    {
                        Start = new RobotPosition(3, 2, RobotApp.Enums.Orientation.N),
                        End = new RobotPosition(4, 3, RobotApp.Enums.Orientation.W),
                        Commands = new List<char> { 'F', 'R', 'R', 'F', 'L', 'L' }
                    }
                }
            };

            var sut = new RobotInstructionFileReader(Path.Combine("TestCommandFiles", "SimpleSample.txt"));
            var actual = sut.Read();

            Assert.That(actual, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(actual.GridDimensions, Is.EqualTo(expected.GridDimensions));
                Assert.That(actual.Obstacles, Is.EqualTo(expected.Obstacles));

                Assert.That(actual.Journeys.First().Start, Is.EqualTo(expected.Journeys.First().Start));
                Assert.That(actual.Journeys.First().End, Is.EqualTo(expected.Journeys.First().End));
                Assert.That(actual.Journeys.First().Commands, Is.EqualTo(expected.Journeys.First().Commands));

                Assert.That(actual.Journeys.Last().Start, Is.EqualTo(expected.Journeys.Last().Start));
                Assert.That(actual.Journeys.Last().End, Is.EqualTo(expected.Journeys.Last().End));
                Assert.That(actual.Journeys.Last().Commands, Is.EqualTo(expected.Journeys.Last().Commands));
            });
        }
    }
}