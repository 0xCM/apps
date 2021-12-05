//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ToolCmdSpec : ITextual
    {
        /// <summary>
        /// The path to the tool executable
        /// </summary>
        public FS.FilePath ToolPath;

        /// <summary>
        /// The arguments to pass to the tool
        /// </summary>
        public Index<string> Args;
        public string Format()
            => string.Format("{0} {0}", ToolPath.Format(PathSeparator.BS), Args.Format());
    }
}