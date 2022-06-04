//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ToolCmdContext
    {
        /// <summary>
        /// The working folder, if any
        /// </summary>
        public FS.FolderPath WorkingDir;

        /// <summary>
        /// Environment variables to use, if any
        /// </summary>
        public NamedValues<string> EnvVars;
    }
}