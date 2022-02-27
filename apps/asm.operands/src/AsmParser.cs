//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using SP = SymbolicParse;

    public readonly struct AsmParser
    {
        public static Outcome encid(ReadOnlySpan<char> src, out EncodingId dst)
        {
            var input = text.trim(src);
            dst = EncodingId.Empty;
            var result = DataParser.parse(input, out Hex64 encid);
            if(result)
                dst = encid;
            return result;
        }

        public static Outcome instid(ReadOnlySpan<char> src, out InstructionId dst)
        {
            var input = text.trim(src);
            dst = InstructionId.Empty;
            if(input.Length != 24)
                return false;
            var x0 = slice(input,0,8);
            var result = DataParser.parse(x0, out Hex32 docid);
            if(result.Fail)
                return result;

            var x1 = slice(input,8,16);
            result = DataParser.parse(x1, out Hex64 encid);
            if(result.Fail)
                return result;

            dst = new InstructionId(docid, encid);
            return true;
        }

        [Parser]
        public static Outcome parse(string src, out AsmMnemonic dst)
        {
            dst = src;
            return true;
        }

        [Parser]
        public static Outcome expression(string src, out AsmExpr dst)
        {
            var body = src.Trim();
            var i = text.index(body, Chars.Space);
            dst = i > 0 ? new AsmExpr(string.Format("{0} {1}", text.left(body,i), text.right(body,i).Trim())) : new AsmExpr(body);
            return true;
        }

        [Parser]
        public static Outcome label(string src, out AsmBlockLabel dst)
        {
            var i = text.index(src, Chars.Colon);
            if(i > 0)
            {
                dst = new AsmBlockLabel(text.left(src,i).Trim());
                return true;
            }
            else
            {
                dst = AsmBlockLabel.Empty;
                return false;
            }
        }

        [Parser]
        public static bool comment(ReadOnlySpan<char> src, out AsmInlineComment dst)
        {
            var count = src.Length;
            var marker = AsmCommentMarker.None;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                switch(c)
                {
                    case (char)AsmCommentMarker.Semicolon:
                    case (char)AsmCommentMarker.Hash:
                        if(marker == 0)
                            marker = (AsmCommentMarker)c;
                        else
                            buffer.Append(c);
                    break;
                    default:
                        if(marker !=0)
                            buffer.Append(c);
                    break;
                }
            }
            var found = marker != 0;
            if(found)
                dst = new AsmInlineComment(marker, buffer.Emit());
            else
                dst = AsmInlineComment.Empty;
            return found;
        }

        [Parser]
        public static Outcome label(string src, out AsmOffsetLabel dst)
        {
            dst = default;
            var result = DataParser.parse(src, out Hex64 value);
            if(result)
                dst = new AsmOffsetLabel(bits.effwidth(value), value);
            return result;
        }

        public static bool label(string src, out AsmAddressLabel dst)
        {
            var input = text.trim(src);
            dst = AsmAddressLabel.Empty;
            var result = false;
            if(text.nonempty(input) && text.begins(input, "_@") && text.ends(input, Chars.Colon))
            {
                var i = text.index(input, Chars.At);
                var j = text.index(input, Chars.Colon);
                if(DataParser.parse(text.inside(input, i, j), out MemoryAddress address))
                {
                    dst = address;
                    result = true;
                }
            }
            return result;
        }

        [Op]
        public static bool asmhex(ReadOnlySpan<char> src, out AsmHexCode dst)
        {
            var storage = Cells.alloc(w128);
            var size = Hex.parse(src, storage.Bytes);
            if(size == 0 || size > 15)
            {
                dst = AsmHexCode.Empty;
                return false;
            }
            else
            {
                dst = new AsmHexCode(storage);
                dst.Cell(15) = (byte)size;
                return true;
            }
        }

        [Op]
        public static AsmHexCode asmhex(string src)
        {
            var dst = AsmHexCode.Empty;
            AsmParser.asmhex(src.Trim(), out dst);
            return dst;
        }

        public static Outcome parse(in AsciLine src, out AsmBlockLabel label, out AsmExpr expr)
        {
            label = AsmBlockLabel.Empty;
            expr = AsmExpr.Empty;
            var content = src.Codes;
            var i = SQ.index(content, AsciCode.Colon);
            if(i < 0)
                return false;

            label = new AsmBlockLabel(text.format(SQ.left(content, i)).Trim());
            expr = text.format(SQ.right(content, i)).Replace(Chars.Tab,Chars.Space).Trim();

            return true;
        }

        public static Outcome parse(ReadOnlySpan<AsciCode> src, out AsmExpr dst)
        {
            dst = AsmExpr.Empty;
            var outcome = Outcome.Success;
            var i = SP.SkipWhitespace(src);
            if(i == NotFound)
                return (false,"Input was empty");

            var remainder = slice(src,i);
            i = SQ.index(remainder, AsciCode.Space);
            if(i == NotFound)
            {
                var monic = new AsmMnemonic(text.format(remainder).Trim());
                var operands = Span<char>.Empty;
                dst = AsmExpr.define(monic, operands);
            }
            else
            {
                var monic = new AsmMnemonic(text.format(slice(remainder,0, i)).Trim());
                var operands = text.format(slice(remainder,i)).Trim();
                dst = AsmExpr.define(monic, operands);
            }

            return outcome;
        }
    }
}