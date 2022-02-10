//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct SymInfo
    {
        public const string TableId = "tokens";

        public const byte FieldCount = 8;

        public Identifier TokenKind;

        public Identifier TokenType;

        public SymClass TokenClass;

        public uint Index;

        public SymVal Value;

        public Identifier Name;

        public SymExpr Expr;

        public TextBlock Description;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24,24,32,8,16,32,32,1};
    }
}