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
        /// Occuress when <see cref="DataBase{T}"/> has been tried to initialize with a mismatched parameter T.
        /// </summary>
        public class TypeMismatchException : Exception
        {
            public TypeMismatchException(string message) : base(message) { }
        }
    }
}
