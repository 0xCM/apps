//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using SQ = SymbolicQuery;
    using C = AsciCode;

    [ApiHost]
    public readonly struct SymbolicParse
    {
        [Parser]
        public static Outcome parse(string src, out SymLiteralRow dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = text.split(src,Chars.Pipe);
            if(cells.Length != SymLiteralRow.FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
            }

            DataParser.parse(skip(cells,j++), out dst.Component);
            DataParser.parse(skip(cells,j++), out dst.Type);
            parse(skip(cells,j++), out dst.Class);
            DataParser.parse(skip(cells,j++), out dst.Position);
            DataParser.parse(skip(cells,j++), out dst.Name);
            parse(skip(cells,j++), out dst.Symbol);
            DataParser.eparse(skip(cells,j++), out dst.DataType);
            parse(skip(cells,j++), out dst.Value);
            DataParser.eparse(skip(cells,j++), out dst.NumericBase);
            DataParser.parse(skip(cells,j++), out dst.Hidden);
            DataParser.parse(skip(cells,j++), out dst.Description);
            DataParser.parse(skip(cells,j++), out dst.Identity);
            return outcome;
        }

        public static Outcome parse(TextLine src, out SymLiteralRow dst)
            => parse(src.Content, out dst);

        public static Outcome parse(TextLine src, out SymInfo dst)
            => parse(src.Content, out dst);

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
            parse(skip(cells,j++), out dst.TokenClass);
            DataParser.parse(skip(cells,j++), out dst.Index);
            parse(skip(cells,j++), out dst.Value);
            DataParser.parse(skip(cells,j++), out dst.Name);
            parse(skip(cells,j++), out dst.Expr);
            DataParser.parse(skip(cells,j++), out dst.Description);
            return outcome;
        }

        [Parser]
        public static Outcome parse(string src, out SymKey dst)
        {
            dst = default;
            var result = DataParser.parse(src, out uint x);
            if(result)
                dst = x;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out SymVal dst)
        {
            dst = default;
            var result = DataParser.parse(src, out ulong x);
            if(result)
                dst = x;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out SymClass dst)
        {
            dst = new SymClass(src);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out SymExpr dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

    }
}