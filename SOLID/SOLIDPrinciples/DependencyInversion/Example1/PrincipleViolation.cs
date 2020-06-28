using System;
using System.Collections.Generic;
using System.IO;
namespace DependencyInversion.Example1.PrincipleViolation
{
    public class GizmoProcessor
    {
        public void Process()
        {
            var logger = new TextLogger();
            logger.WriteLogMessage("Something happened");
        }
    }

    public class TextLogger
    {
        public void WriteLogMessage(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
