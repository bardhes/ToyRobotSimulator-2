namespace RobotApp
{
    using System;
    using System.IO;
    using RobotApp.Processors;

    class Program
    {
        private const string CommandDataFolder = "CommandFiles";

        static void Main()
        {
            Console.WriteLine("Welcome!!!!");
            Console.WriteLine("Enter the name of the sample you wish to process.");
            Console.WriteLine("Hint: Sample.txt, Sample1.txt or Sample2.txt only.");

            var continueProcessing = true;

            do
            {
                var commandFile = Console.ReadLine();

                try
                {
                    string output = UserCommandProcessor.ProcessCommand(Path.Combine(CommandDataFolder, commandFile));

                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        Console.WriteLine(output);
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("I'm really sorry, but something went wrong.");
                    Console.WriteLine("Maybe try again later?");

                    // Log the exception
                }

                Console.WriteLine("Process another file?");
                Console.WriteLine("Hint: Y or N.");

                var continueProcessingResponse = Console.ReadLine();
                continueProcessing = continueProcessingResponse.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueProcessing);
        }
    }
}
