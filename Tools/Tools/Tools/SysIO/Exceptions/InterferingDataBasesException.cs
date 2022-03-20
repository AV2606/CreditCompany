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
        /// Occures when a <see cref="DataBase{T}"/> has been tried to initialized when another parameter T <see cref="DataBase{T}"/> with the same
        /// <see cref="DataBase.FullURL"/> has been already initialized.
        /// </summary>
        public class InterferingDataBasesException : Exception
        {
            public InterferingDataBasesException(string message) : base(message)
            {
            }
        }
    }
}
