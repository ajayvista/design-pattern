using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DependencyInversion.Example1.WithPrinciple
{
    public interface IGizmoProcessor
    {
        void Process();
    }

    public interface ILogger
    {
        void WriteLogMessage(string Message);
    }

    public class GizmoProcessor : IGizmoProcessor
    {
        private readonly ILogger _logger;
        public GizmoProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public void Process()
        {
            // do something
            _logger.WriteLogMessage("Something happened");
        }
    }

    public class TextLogger : ILogger
    {
        public void WriteLogMessage(string Message)
        {
            //logic here
            Console.WriteLine(Message);
        }
    }
}
