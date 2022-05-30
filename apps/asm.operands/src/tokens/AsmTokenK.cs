//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct AsmToken2
    {
        public const string TableId = "asm.tokens";

        [Render(12)]
        public uint Seq;

        [Render(12)]
        public uint Index;

        [Render(16)]
        public string Group;

        [Render(12)]
        public uint KindIndex;

        [Render(24)]
        public string KindName;

        [Render(24)]
        public string Name;

        [Render(16)]
        public SymVal Value;

        [Render(16)]
        public SymExpr Expr;
    }

    [Record(TableId)]
    public struct AsmToken
    {
        public const string TableId = "asm.tokens";

        public const byte FieldCount = 9;

        [Render(12)]
        public uint Seq;

        [Render(12)]
        public Hex32 Id;

        [Render(16)]
        public Identifier ClassName;

        [Render(16)]
        public Identifier KindName;

        [Render(16)]
        public Identifier Name;

        [Render(12)]
        public ushort Index;

        [Render(12)]
        public byte KindValue;

        [Render(12)]
        public byte Value;

        [Render(1)]
        public @string Expr;

        public static AsmToken Empty => default;
    }
}