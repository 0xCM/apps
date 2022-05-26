//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ToolProfile
    {
        public const string TableId = "tool.profiles";

        public const byte FieldCount = 5;

        public ToolId Id;

        public string Modifier;

        public CmdArg HelpCmd;

        public ToolId Memberhisp;

        public FS.FilePath Path;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{32,16,32,32,5};
    }
}