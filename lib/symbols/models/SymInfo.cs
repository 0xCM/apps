//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(StructLayout), Record(TableId)]
    public struct SymInfo
    {
        public const string TableId = "tokens";

        public const byte FieldCount = 8;

        [Parser]
        public static Outcome parse(string src, out SymInfo dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != SymInfo.FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
            }

            DataParser.parse(skip(cells,j++), out dst.TokenKind);
            DataParser.parse(skip(cells,j++), out dst.TokenType);
            DataParser.parse(skip(cells,j++), out dst.TokenClass);
            DataParser.parse(skip(cells,j++), out dst.Index);
            DataParser.parse(skip(cells,j++), out dst.Value);
            DataParser.parse(skip(cells,j++), out dst.Name);
            DataParser.parse(skip(cells,j++), out dst.Expr);
            DataParser.parse(skip(cells,j++), out dst.Description);
            return outcome;
        }

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

        [Render(64)]
        public Identifier Name;

        [Render(64)]
        public SymExpr Expr;

        [Render(1)]
        public TextBlock Description;
    }
}