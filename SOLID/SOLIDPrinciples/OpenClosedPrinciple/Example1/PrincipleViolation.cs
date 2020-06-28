using System;
using System.Diagnostics;
using System.IO;
namespace OpenClosedPrincipleEx0.Example1
{
    public class ErrorLogger
    {
        private readonly string _whereToLog;

        public ErrorLogger(string whereToLog)
        {
            this._whereToLog = whereToLog.ToUpper();
        }

        public void LogError(string message)
        {
            switch (_whereToLog)
            {
                case "TEXTFILE":
                    WriteTextFile(message);
                    break;
                case "EVENTLOG":
                    WriteEventLog(message);
                    break;
                default:
                    throw new Exception("Unable to log error");
            }
        }

        private void WriteTextFile(string message)
        {
            System.IO.File.AppendAllText(@"Errors.txt", message);
        }

        private void WriteEventLog(string message)
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
