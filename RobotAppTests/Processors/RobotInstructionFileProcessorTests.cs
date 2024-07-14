namespace RobotAppTests.Processors
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;
    using RobotApp.Processors;
    using System.Drawing;

    public class RobotInstructionFileProcessorTests
    {
        [Test]
        public void ProcessFileContents_NoJourneys_ShouldThrow()
        {
            var actual = Assert.Throws<RobotAppException>(() => RobotInstructionFileProcessor.ProcessFileContents(new RobotInstructionFile
            {
                GridDimensions = new Size(),
                Journeys = new List<Journey>()
            }));

            Assert.That(actual.Message, Is.EqualTo(ExceptionMessages.JourneySectionMissing));
        }

        [Test]
        public void ProcessFileContents_SampleJourneys_ShouldReturnExpectedMessage()
        {
            var actual = RobotInstructionFileProcessor.ProcessFileContents(new RobotInstructionFile
            {
                GridDimensions = new Size(4, 3),
                Journeys = new List<Journey>
                {
                    new ()
                    {
                        Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                        End = new RobotPosition(1, 0, RobotApp.Enums.Orientation.W),
                        Commands = new List<char> {'R', 'F', 'R' }
                    },
                    new ()
                    {
                        Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                        End = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                        Commands = new List<char> {'R', 'F', 'R', 'F' }
                    },
                    new ()
                    {
                        Start = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                        End = new RobotPosition(1, 1, RobotApp.Enums.Orientation.E),
                        Commands = new List<char> {'R', 'F', 'F' }
                    }
                }
            });

            Assert.That(actual, Is.EqualTo("SUCCESS 1 0 W\r\nFAILURE 0 0 W\r\nOUT OF BOUNDS\r\n"));
        }
    }
}