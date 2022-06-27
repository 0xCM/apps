//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedTool
    {
        [StructLayout(LayoutKind.Sequential, Pack=1), Cmd(CmdName)]
        public struct XedToolCmd : IToolFlowCmd<XedToolCmd>
        {
            const string CmdName = "xedtool.cmd";

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

            IActor IFlowCmd.Actor
                => Z0.Tools.xed;

            FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Source
                => Source;

            FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Target
                => Target;
        }
    }
}