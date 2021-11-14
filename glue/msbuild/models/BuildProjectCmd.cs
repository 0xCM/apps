//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    [Cmd(CmdName)]
    public struct BuildProjectCmd : ICmd<BuildProjectCmd>
    {
        public const string CmdName = "build";

        public FS.FilePath SolutionPath;

        public FS.FilePath ProjectPath;

        public FS.FilePath LogFile;

        public string Configuration;

        public string Platform;

        public BuildLogVerbosity Verbosity;

        public byte MaxCpuCount;

        public bool Graph;
    }
}