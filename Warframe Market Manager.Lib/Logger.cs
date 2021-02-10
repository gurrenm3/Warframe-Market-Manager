using System;

namespace Warframe_Market_Manager.Lib
{
    /// <summary>
    /// This class sends messages to the user
    /// </summary>
    public class Logger
    {
        #region Properties

        private static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();

                return instance;
            }
        }
        #endregion

        #region Events
        public static event EventHandler<LogEvents> MessageLogged;

        public class LogEvents : EventArgs
        {
            public string Message { get; set; }
            public int MessageDisplayTime { get; set; }
        }

        /// <summary>
        /// When a message has been sent to the Output() function
        /// </summary>
        /// <param name="e">LogEvent args containing the output message</param>
        public void OnMessageLogged(LogEvents e)
        {
            EventHandler<LogEvents> handler = MessageLogged;
            if (handler != null)
                handler(this, e);
        }

        #endregion


        /// <summary>
        /// Passes message to OnMessageLogged for Event Handling.
        /// </summary>
        /// <param name="text">Message to output to user</param>
        public static void Log(string text)
        {
            LogEvents args = new LogEvents();
            args.Message = text;
            Instance.OnMessageLogged(args);
        }

        public static void Log(bool comparison) => Log(comparison.ToString());
    }
}
