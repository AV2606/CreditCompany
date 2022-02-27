using System.Collections.Generic;
//Version 0.5

namespace Tools
{

    /// <summary>
    /// Encapuslate communication with the system and files.
    /// </summary>
    namespace SysIO
    {
        /// <summary>
        /// Writes the data with the desired method.
        /// </summary>
        public enum WriteMode
        {
            /// <summary>
            /// Appends this data to the end of the data base.
            /// </summary>
            Append = 0,
            /// <summary>
            /// Overwrites the whole database with this data.
            /// </summary>
            Overwrite = 1
        }

        /// <summary>
        /// A base class for <see cref="GenericDataBase{T}"/>
        /// </summary>
        public class DataBase
        {
            protected static List<DataBase> bases = new List<DataBase>();
            /// <summary>
            /// All the Initialized data bases of any type.
            /// </summary>
            public static IReadOnlyList<DataBase> Bases { get => bases; }

            /// The location of the database.
            /// </summary>
            public string URL { get; set; } = "\\";
            /// <summary>
            /// The file extension of this database file.
            /// </summary>
            public readonly string FileExtension;
            /// <summary>
            /// Returns the full URL of the DataBase.
            /// </summary>
            public string FullURL => URL + FileExtension;

            protected DataBase(string url,string fileExtension)
            {
                this.URL = url;
                this.FileExtension = fileExtension;
            }
            protected DataBase(string fullURL)
            {
                int dotindex = fullURL.LastIndexOf('.');
                string ex = fullURL.Substring(dotindex);
                this.FileExtension = ex;
                this.URL = fullURL.Substring(0, dotindex);
            }
        }
    }
}
