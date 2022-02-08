//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedTool;

    [StructLayout(LayoutKind.Sequential, Pack=1), Cmd(CmdName)]
    public struct XedToolCmd : IFileFlowCmd<XedToolCmd>
    {
        public const string CmdName = "xedtool.cmd";

        [CmdArg("<src>")]
        public FS.FilePath Source;

        [CmdArg("<dst>")]
        public FS.FilePath Target;

        [CmdArg("-{0}")]
        public InputKind InputKind;

        [CmdArg("-v {0}")]
        public Verbosity Verbosity;

        [CmdArg("-{0}")]
        public Mode Mode;

        IActor IFileFlowCmd.Actor
            => Tools.xed;

        FS.FilePath IFileFlowCmd.Source
            => Source;

        FS.FilePath IFileFlowCmd.Target
            => Target;
    }
}