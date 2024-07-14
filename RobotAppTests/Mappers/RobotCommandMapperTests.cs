namespace RobotApp.Mappers
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public class RobotCommandMapperTests
    {
        [TestCaseSource(nameof(EmptyCommandTestCases))]
        public void Map_RobotCommandisEmpty_ThrowsException(string robotCommands)
        {
            var ex = Assert.Throws<RobotAppException>(() => RobotCommandMapper.Map(robotCommands));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.RobotCommandIsEmpty));
        }

        static IEnumerable<string> EmptyCommandTestCases()
        {
            yield return null!;
            yield return string.Empty;
            yield return " ";
        }

        [TestCaseSource(nameof(InvalidCommandTestCases))]
        public void Map_RobotCommandContainsInvalidCommands_ThrowsException(string robotCommands)
        {
            var ex = Assert.Throws<RobotAppException>(() => RobotCommandMapper.Map(robotCommands));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.RobotCommandContainsUnknownCommands));
        }

        static IEnumerable<string> InvalidCommandTestCases()
        {
            yield return "FLRB";
            yield return "L!";
            yield return "#";
        }

        [TestCaseSource(nameof(ValidCommandTestCases))]
        public void Map_RobotCommandContainsValidCommands_MapsCorrectly((string robotCommands, IEnumerable<char> expected) testCase)
        {
            var actual = RobotCommandMapper.Map(testCase.robotCommands);
            Assert.That(actual, Is.EqualTo(testCase.expected));
        }

        static IEnumerable<(string, IEnumerable<char>)> ValidCommandTestCases()
        {
            yield return ("FLR", new[] { 'F', 'L', 'R' });
            yield return ("LRLRLRF", new[] { 'L', 'R', 'L', 'R', 'L', 'R', 'F' });
            yield return ("RFFFFL", new[] { 'R', 'F', 'F', 'F', 'F', 'L' });
        }
    }
}
