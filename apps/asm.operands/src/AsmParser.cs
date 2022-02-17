//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmParser
    {
        [Parser]
        public static Outcome parse(string src, out AsmMnemonic dst)
        {
            dst = src;
            return true;
        }

        [Parser]
        public static Outcome expression(string src, out AsmExpr dst)
        {
            dst = text.trim(src);
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
    }
}