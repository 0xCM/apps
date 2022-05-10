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

        [Render(12)]
        public uint Seq;

        [Render(12)]
        public Hex32 Id;

        [Render(16)]
        public Identifier ClassName;

        [Render(16)]
        public Identifier KindName;

        [Render(12)]
        public byte KindValue;

        [Render(12)]
        public ushort Index;

        [Render(16)]
        public Identifier Name;

        [Render(12)]
        public byte Value;

        [Render(1)]
        public @string Expression;

        public static AsmToken Empty => default;
    }
}