//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using System;

    [Record(TableId)]
    public struct ApiCmdRow
    {
        public const string TableId = "api.commands";

        public const byte FieldCount = 5;

        public @string CmdName;

        public @string ArgName;

        public TypeSpec DataType;

        public @string Expression;

        public @string Value;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{36,36,48,32,3};
    }
}