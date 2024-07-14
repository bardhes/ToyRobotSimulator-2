namespace RobotApp.Processors
{
    public static class UserCommandProcessor
    {

        public static string ProcessCommand(string filePath)
        {
            var instructionFile = new RobotInstructionFileReader(filePath).Read();

            var result = RobotInstructionFileProcessor.ProcessFileContents(instructionFile);
            return result;
        }
    }
}