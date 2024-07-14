namespace RobotApp.Processors
{
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;

    public static class JourneyCommandProcessor
    {
        public static string ProcessJourneyCommands(Grid grid, Journey journey)
        {
            // TODO: Null checks
            var robot = new Robot(journey.Start);

            try
            {
                var simulator = new Simulator(robot, grid);

                foreach (var command in journey.Commands)
                {
                    RobotCommandProcessor.ProcessCommand(simulator, command);
                }

                return $"{(simulator.MyRobot.Position.Equals(journey.End) ? "SUCCESS" : "FAILURE")} {simulator.Report()}";
            }
            catch (OutOfBoundsException ex)
            {
                return $"{ex.Message}";
            }
            catch (ObstacleCrashException ex)
            {
                return $"{ex.Message}";
            }
        }
    }
}