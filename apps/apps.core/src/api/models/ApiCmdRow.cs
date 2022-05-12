//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ApiCmdRow
    {
        public const string TableId = "api.commands";

        public const byte FieldCount = 6;

        public string CmdName;

        public string CmdType;

        public string ArgName;

        public TypeSpec DataType;

        public string Expression;

        public string DefaultValue;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{22,22,36,48,32,3};
    }
}