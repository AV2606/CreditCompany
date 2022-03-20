using System;
//Version 0.4

namespace Tools
{
    /// <summary>
    /// Encapuslate communication with the system and files.
    /// </summary>
    namespace SysIO
    {
        /// <summary>
        /// Occures when theres been an attmept to use a non-existing or inavlid URL.
        /// </summary>
        public class InvalidURLException : Exception
        {
            public InvalidURLException(string message) : base(message)
            {
            }
        }
    }
}
