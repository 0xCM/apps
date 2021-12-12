//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    [ApiHost]
    public readonly struct SymbolicParse
    {
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

            outcome += DataParser.parse(skip(cells,j++), out dst.Component);
            outcome += DataParser.parse(skip(cells,j++), out dst.Type);
            outcome += DataParser.parse(skip(cells,j++), out dst.Class);
            outcome += DataParser.parse(skip(cells,j++), out dst.Position);
            outcome += DataParser.parse(skip(cells,j++), out dst.Name);
            outcome += DataParser.parse(skip(cells,j++), out dst.Symbol);
            outcome += DataParser.eparse(skip(cells,j++), out dst.DataType);
            outcome += DataParser.parse(skip(cells,j++), out dst.ScalarValue);
            outcome += DataParser.parse(skip(cells,j++), out dst.Hidden);
            outcome += DataParser.parse(skip(cells,j++), out dst.Description);
            outcome += DataParser.parse(skip(cells,j++), out dst.Identity);
            return outcome;
        }

        [Parser]
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

            outcome += DataParser.parse(skip(cells,j++), out dst.TokenType);
            outcome += DataParser.parse(skip(cells,j++), out dst.Index);
            outcome += DataParser.parse(skip(cells,j++), out dst.Value);
            outcome += DataParser.parse(skip(cells,j++), out dst.Name);
            outcome += DataParser.parse(skip(cells,j++), out dst.Expr);
            outcome += DataParser.parse(skip(cells,j++), out dst.Description);
            return outcome;
        }

        [Op]
        public static int SkipWhitespace(ReadOnlySpan<AsciCode> src)
        {
            var count = src.Length;
            var i=0;
            while(i < count)
            {
                if(!SQ.whitespace(skip(src,i)))
                    return i;
                else
                    i++;
            }
            return NotFound;
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

        /// <summary>
        /// Parsed the leading digit sequence of a given row
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static Outcome digits(Base10 @base, in AsciLine src, ref uint i, out ushort dst)
        {
            var i0 = i;
            var result = Outcome.Success;
            dst = default;
            var data = slice(src.Codes, i);
            var length = data.Length;
            for(; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(SQ.whitespace(c))
                    continue;

                if(SQ.digit(@base, c))
                {
                    result = parse(@base, slice(data,i), out dst);
                    break;
                }
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<AsciCode> src, Span<char> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(src,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<char> src, Span<AsciCode> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (AsciCode)skip(src,i);
            return count;
        }

        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<AsciCode> src, out ushort dst)
        {
            var storage = CharBlock16.Null;
            var buffer = storage.Data;
            convert(src, buffer);
            return ScalarParser.parse(@base, buffer, out dst);
        }

        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<AsciCode> src, ref uint i, out ushort dst)
        {
            dst = default;
            var result = Outcome.Success;
            var input = slice(src,i);
            var length = input.Length;
            var digits = SQ.digits(n16, base10, input);
            if(digits.Length == 0)
                result = (false,"No digits found");
            else
            {
                result = parse(@base, digits, out dst);
                if(result.Ok)
                    i += (uint)digits.Length;
            }
            return result;
        }
    }
}