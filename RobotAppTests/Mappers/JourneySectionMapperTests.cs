namespace RobotApp.Mappers
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public class JourneySectionMapperTests
    {
        [TestCaseSource(nameof(NotThreeCommandsTestCases))]
        public void Map_JourneyCommandDoesNotHaveExactlyThreeCommands_ThrowsException(IEnumerable<string> journeyCommands)
        {
            var ex = Assert.Throws<RobotAppException>(() => JourneySectionMapper.Map(journeyCommands));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.JourneyShouldBeMadeUpOfExactlyThreeLines));
        }

        static IEnumerable<IEnumerable<string>> NotThreeCommandsTestCases()
        {
            yield return new List<string> { "Only one" }; // TODO: Might be a subtle bug/edge case to fix here.
            yield return new string[] { "Only one...", "... two" };
            yield return new string[] { "One", "Two", "Three", "Too many" };
        }
    }
}
