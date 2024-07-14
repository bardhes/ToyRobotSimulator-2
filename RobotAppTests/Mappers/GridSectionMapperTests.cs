namespace RobotApp.Mappers
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;

    public class GridSectionMapperTests
    {
        [TestCase("GRID 5x5 //TooMany")]
        [TestCase("//TooFew")]
        public void Map_GridCommandHasWrongNumberOfParts_ThrowsException(string command)
        {
            var ex = Assert.Throws<RobotAppException>(() => GridSectionMapper.Map(command));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridCommandNotInExpectedFormat));
        }

        [TestCase("GRID 5by5")]
        [TestCase("GRID 5x5x5")]
        [TestCase("GRID 5x")]
        public void Map_GridCommandSecondPartIsUnexpectedFormat_ThrowsException(string command)
        {
            var ex = Assert.Throws<RobotAppException>(() => GridSectionMapper.Map(command));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridDefinitionNotInExpectedFormat));
        }

        [TestCase("FIVExFIVE")]
        [TestCase("5.5x5.5")]
        [TestCase("10000000000x10000000000")]
        public void Map_GridCommandDimensionsNotParseableAsInts_ThrowsException(string secondPart)
        {
            var ex = Assert.Throws<RobotAppException>(() => GridSectionMapper.Map($"GRID {secondPart}"));
            Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.GridDefinitionDoesNotHaveExpectedDataTypes));
        }

        [TestCase("50x45", 50, 45)]
        [TestCase("36x12", 36, 12)]
        [TestCase("1000000000x1000000000", 1000000000, 1000000000)]
        public void Map_ValidGridCommand_ReturnsSize(string secondPart, int expectedWidth, int expectedHeight)
        {
            var size = GridSectionMapper.Map($"GRID {secondPart}");

            Assert.Multiple(() =>
            {
                Assert.That(size.Width, Is.EqualTo(expectedWidth));
                Assert.That(size.Height, Is.EqualTo(expectedHeight));
            });
        }
    }
}
