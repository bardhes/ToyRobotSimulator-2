namespace RobotAppTests.Processors
{
    using System.Text;
    using RobotApp.Processors;

    [TestFixture]
    class FileProcessorIntegrationTests
    {
        private readonly string Sample = "TestCommandFiles/Sample.txt";
        private readonly string Sample1 = "TestCommandFiles/Sample1.txt";
        private readonly string Sample2 = "TestCommandFiles/Sample2.txt";

        [Test]
        public void Simulator_ProcessFile_CommandsToMoveRobotFrom00NorthReports01North()
        {
            var expected = new StringBuilder();
            expected.AppendLine("SUCCESS 1 0 W");
            expected.AppendLine("FAILURE 0 0 W");
            expected.AppendLine("OUT OF BOUNDS");

            var actual = UserCommandProcessor.ProcessCommand(Sample);

            Assert.That(actual, Is.EqualTo(expected.ToString()));
        }

        [Test]
        public void Simulator_ProcessFile_CommandsToLeftTurnRobotFrom00NorthReports01North()
        {
            var expected = new StringBuilder();
            expected.AppendLine("SUCCESS 1 1 E");
            expected.AppendLine("SUCCESS 3 3 N");
            expected.AppendLine("SUCCESS 2 4 S");

            string actual = UserCommandProcessor.ProcessCommand(Sample1);

            Assert.That(actual, Is.EqualTo(expected.ToString()));
        }

        [Test]
        public void Simulator_ProcessFile_CommandsToMoveAndLeftTurnRobotReportCorrectLocation()
        {
            var expected = new StringBuilder();
            expected.AppendLine("SUCCESS 1 1 E");
            expected.AppendLine("SUCCESS 3 3 N");
            expected.AppendLine("CRASHED 1 3");

            string actual = UserCommandProcessor.ProcessCommand(Sample2);

            Assert.That(actual, Is.EqualTo(expected.ToString()));
        }
    }
}
