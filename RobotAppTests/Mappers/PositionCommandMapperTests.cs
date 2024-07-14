namespace RobotApp.Mappers
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public class PositionCommandMapperTests
    {
        [TestCaseSource(nameof(NotThreePartsToThecommandTestCases))]
        public void Map_PositionCommandDoesNotHaveExactlyThreeParts_ThrowsException(string positionCommand)
        {
            var ex = Assert.Throws<RobotAppException>(() => PositionCommandMapper.Map(positionCommand));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.RobotPositionCommandDoesNotHaveCorrectNumberOfElements));
        }

        static IEnumerable<string> NotThreePartsToThecommandTestCases()
        {
            yield return "One";
            yield return "Only Two";
            yield return "One Two Three TooMany";
        }

        [TestCaseSource(nameof(InvalidOrientationTestCases))]
        public void Map_PositionCommandDoesNotHaveAValidOrientation_ThrowsException(string positionCommand)
        {
            var ex = Assert.Throws<RobotAppException>(() => PositionCommandMapper.Map(positionCommand));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.RobotPositionCommandDoesNotHaveValidOrientation));
        }

        static IEnumerable<string> InvalidOrientationTestCases()
        {
            yield return "1 2 5";
            yield return "1 2 SE";
        }

        [TestCaseSource(nameof(ThreePartsDoNotParseTestCases))]
        public void Map_PositionCommandDoesNotParseCorrectly_ThrowsException(string positionCommand)
        {
            var ex = Assert.Throws<RobotAppException>(() => PositionCommandMapper.Map(positionCommand));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.RobotPositionCommandDoesNotHaveCorrectDataTypes));
        }

        static IEnumerable<string> ThreePartsDoNotParseTestCases()
        {
            yield return "1 Two N";
            yield return "One 2 S";
            yield return "1.1 2 E";
        }
    }
}
