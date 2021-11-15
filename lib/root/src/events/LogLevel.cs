//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Classifier for application messages
    /// </summary>
    public enum LogLevel : byte
    {
        /// <summary>
        /// Boring
        /// </summary>
        None = ConsoleColor.White,

        /// <summary>
        /// Identifies chatty content
        /// </summary>
        Babble = ConsoleColor.DarkGray,

        /// <summary>
        /// Identifies informational content
        /// </summary>
        Status = ConsoleColor.Cyan,

        /// <summary>
        /// Identifies warning content
        /// </summary>
        Warning = ConsoleColor.Yellow,

        /// <summary>
        /// Identifies error content
        /// </summary>
        Error = ConsoleColor.Red,
    }
}