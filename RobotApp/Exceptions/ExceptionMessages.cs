using RobotApp.Enums;

namespace RobotApp.Exceptions
{
    public static class ExceptionMessages
    {
        public static string FileExtensionInvalid(string filePath)
        {
            return $"{filePath} has been ignored because it is not a txt file type.";
        }

        public static string FileReadProblem(string filePath)
        {
            return $"There was a problem reading the file at {filePath}.";
        }

        public static string InvalidRobotCommand(char command)
        {
            return $"Invalid robot command: {command}";
        }

        public static string FileIsEmpty => "The file was empty.";

        public static string FileFullOfEmptyLines => "The file was full of empty lines.";

        public static string GridDefinitionMustBeFirst => "The first command must define the grid.";

        public static string GridMustOnlyBeDefinedOnce => "The grid should only be defined once per file.";

        public static string GridDefinitionMustBeFirstAndOnlyOne => "The grid definition should only be defined once and should be the first instruction.";

        public static string GridCommandNotInExpectedFormat => "The grid command is not in the expected format.";

        public static string GridDefinitionNotInExpectedFormat => "The grid definition is not in the expected format.";

        public static string GridDefinitionDoesNotHaveExpectedDataTypes => "The grid definition does not have the expected data types.";

        public static string ObstacleSectionShouldBeAfterGridSection => "The obstacle section should only be defined after the grid definition.";

        public static string ObstacleSectionShouldOnlyContainObstacleCommands => "The obstacle section should only contain obstacle commands.";

        public static string ObstacleCommandsShouldHaveThreeElements => "Obstacle commands should have three elements.";

        public static string ObstacleCommandDidNotHaveCorrectDataTypes => "Obstacle command did not have the correct data types.";

        public static string JourneySectionMissing => "The file contains no journey instructions.";

        public static string JourneyShouldBeMadeUpOfExactlyThreeLines => "A journey should be made up of exactly three lines.";

        public static string RobotPositionOrientationNotSupportedForTurn(Orientation orientation) => $"The current robot orientation ({orientation}) is not supported for this action.";

        public static string RobotPositionCommandDoesNotHaveCorrectNumberOfElements => "The robot position doesn't have the correct number of elements.";

        public static string RobotPositionCommandDoesNotHaveValidOrientation => "The robot position doesn't have a valid orientation.";

        public static string RobotPositionCommandDoesNotHaveCorrectDataTypes => "The robot position command doesn't have the correct data types.";

        public static string RobotCommandIsEmpty => "The robot command is empty.";

        public static string RobotCommandContainsUnknownCommands => "The robot command contains unknown commands.";
    }
}
