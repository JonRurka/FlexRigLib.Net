using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FlexRigLib.Net
{
    public class Logger
    {
        public enum Level
        {
            Error = 3,
            Warning = 2,
            Info = 1,
            Debug = 0
        }

        public struct LogEntry
        {
            public Level log_level;
            public string source;
            public string message;
        }

        [DllImport(Settings.DLL)]
        private static extern int Logger_PrepareMessages();

        [DllImport(Settings.DLL)]
        private static extern int Logger_GetMessage(int index, StringBuilder out_msg, StringBuilder message);

        public static LogEntry[] GetMessages()
        {
            int numEntries = Logger_PrepareMessages();

            LogEntry[] entries = new LogEntry[numEntries];

            StringBuilder source = new StringBuilder(100);
            StringBuilder message = new StringBuilder(10000);

            for (int i = 0; i < numEntries; i++)
            {
                entries[i].log_level = (Level)Logger_GetMessage(i, source, message);
                entries[i].source = source.ToString();
                entries[i].message = message.ToString();
            }

            return entries;
        }
    }
}
