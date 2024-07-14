namespace RobotApp.Processors
{
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;
    using System.Linq;
    using System.Text;

    public static class RobotInstructionFileProcessor
    {
        public static string ProcessFileContents(RobotInstructionFile robotInstructionFile)
        {
            if (!robotInstructionFile.Journeys.Any())
            {
                throw new RobotAppException(ExceptionMessages.JourneySectionMissing);
            }

            StringBuilder responseBuilder = new();

            var grid = new Grid
            {
                Dimensions = robotInstructionFile.GridDimensions,
                Obstacles = robotInstructionFile.Obstacles
            };

            foreach (var journey in robotInstructionFile.Journeys)
            {
                //TODO: Might be cleaner to do this directly in the Simulator.
                responseBuilder.AppendLine(JourneyCommandProcessor.ProcessJourneyCommands(grid, journey));
            }

            return responseBuilder.ToString();
        }
    }
}