﻿using System;
//Version 0.5

namespace Tools
{
    /// <summary>
    /// Encapuslate communication with the system and files.
    /// </summary>
    namespace SysIO
    {
        #region Base data packs
        /// <summary>
        /// A pack that holds any integer value.
        /// </summary>
        public class IntPack : BasePack
        {
            public new long Data { get => (long)base.Data; set => base.Data = value; }
            public IntPack()
            {
                Data = 0;
            }
            public IntPack(long value)
            {
                Data = value;
            }
            public override IntPack FromStringFile(SingleLineString content) =>
                 new IntPack(Convert.ToInt64((string)content));
            public override SingleLineString ToStringFile() =>
                this.Data + "";

            #region casting
            public static implicit operator IntPack(long value)=>
                new IntPack(value);
            public static explicit operator long(IntPack value)=>
                value.Data;
            #endregion
        }
        #endregion
    }
}
