//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static XedTool;

    [StructLayout(LayoutKind.Sequential, Pack=1), Cmd(CmdName)]
    public struct XedToolCmd : ICmd<XedToolCmd>
    {
        public const string CmdName = "xedtool.cmd";

        public InputKind InputKind;

        public string InputSpec;

        public Verbosity Verbosity;

        public Mode Mode;

        public FS.FilePath OutputPath;
    }
}