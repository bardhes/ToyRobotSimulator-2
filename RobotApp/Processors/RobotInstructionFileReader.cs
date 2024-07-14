namespace RobotApp.Processors
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using RobotApp.Mappers;
    using RobotApp.Exceptions;
    using RobotApp.Exceptions.CustomExceptions;
    using RobotApp.Models;

    public class RobotInstructionFileReader
    {
        private readonly string _filePath;

        public RobotInstructionFileReader(string filePath)
        {
            _filePath = filePath;
        }

        public RobotInstructionFile Read()
        {
            if (Path.GetExtension(_filePath).ToLower() != ".txt")
            {
                throw new RobotAppException(ExceptionMessages.FileExtensionInvalid(_filePath));
            }

            var lines = ReadFile();

            return RobotInstructionFileMapper.Map(lines);
        }

        private IEnumerable<string> ReadFile()
        {
            try
            {
                return File.ReadLines(_filePath);
            }
            catch (Exception ex)
            {
                throw new RobotAppException(ExceptionMessages.FileReadProblem(_filePath), ex);
            }
        }
    }
}
