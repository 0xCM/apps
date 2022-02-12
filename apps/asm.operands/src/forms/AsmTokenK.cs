//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct AsmToken
    {
        public const string TableId = "sdm.tokens";

        public const byte FieldCount = 9;

        public uint Seq;

        public Hex32 Id;

        public Identifier ClassName;

        public Identifier KindName;

        public byte KindValue;

        public ushort Index;

        public Identifier Name;

        public byte Value;

        public @string Expression;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,16,16,12,12,16,12,1};
    }
}