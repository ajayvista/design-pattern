using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace OpenClosedPrincipleEx0.Example1
{
    public interface IErrorLogger
    {
        void LogError(string message);
    }

    public class TextFileErrorLogger : IErrorLogger
    {
        public void LogError(string message)
        {
            System.IO.File.WriteAllText(@"Errors.txt", message);
        }
    }

    public class EventLogErrorLogger : IErrorLogger
    {
        public void LogError(string message)
        {
            string source = "Magazine";
            string log = "Application";

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }

            EventLog.WriteEntry(source, message, EventLogEntryType.Error, 1);
        }
    }
}
