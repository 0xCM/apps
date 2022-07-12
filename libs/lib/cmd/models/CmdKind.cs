//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies concrete command types
    /// </summary>
    public enum CmdKind : byte
    {
        None,

        /// <summary>
        /// Classifies commands that are command-line driven
        /// </summary>
        ToolCmd,

        /// <summary>
        /// Classifies commands that are defined by a data type
        /// </summary>
        TypedCmd,

        /// <summary>
        /// Classifies commands that execute via the shell system
        /// </summary>
        ShellCmd,
    }
}