//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout), Record(TableId)]
    public struct SymInfo
    {
        public const string TableId = "tokens";

        public const byte FieldCount = 8;

        [Render(24)]
        public Identifier TokenKind;

        [Render(24)]
        public Identifier TokenType;

        [Render(32)]
        public SymClass TokenClass;

        [Render(8)]
        public uint Index;

        [Render(16)]
        public SymVal Value;

        [Render(32)]
        public Identifier Name;

        [Render(32)]
        public SymExpr Expr;

        [Render(1)]
        public TextBlock Description;
    }
}