//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct ToolProfile
    {
        public const string TableId = "tool.profiles";

        public const byte FieldCount = 4;

        public ToolId Id;

        public CmdArg HelpCmd;

        public ToolId Memberhisp;

        public FS.FilePath Path;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{32,32,32,5};
    }
}