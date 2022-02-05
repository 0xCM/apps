//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmFormatter
    {
        public static void render(ReadOnlySpan<byte> block, ReadOnlySpan<IceInstruction> instructions, ITextBuffer dst)
        {
            Address16 offset = z16;
            var count = instructions.Length;
            dst.AppendLine(asm.comment(block.FormatHex()));
            for(var i=0; i<count; i++)
            {
                ref readonly var instruction = ref skip(instructions,i);
                var size = instruction.InstructionSize;
                var code = slice(block, offset, size);
                dst.AppendLineFormat("{0,-6} {1,-46} # {2,-2} | {3}", offset, instruction.FormattedInstruction, size, code.FormatHex());
                offset += size;
            }
        }

        public static string header(in MemberEncoding src)
        {
            const string PageBreak = "#" + CharText.Space + RP.PageBreak160;
            const AsmCommentMarker CommentMarker = AsmCommentMarker.Hash;
            const sbyte Pad = -14;
            var dst = text.buffer();
            dst.AppendLine(PageBreak);
            dst.AppendLine(new AsmInlineComment(CommentMarker, $"{src.Sig}::{src.Uri}"));
            dst.AppendLine(AsmInlineComment.array(src.Data).Format());
            dst.AppendLine(new AsmInlineComment(CommentMarker, RP.attrib(Pad, nameof(src.EntryAddress), src.EntryAddress)));
            dst.AppendLine(new AsmInlineComment(CommentMarker, RP.attrib(Pad, nameof(src.TargetAddress), src.TargetAddress)));
            dst.Append(PageBreak);
            return dst.Emit();
        }

        [Op]
        public static string format(AsmRoutine src, in AsmFormatConfig config)
        {
            var dst = text.buffer();
            render(src, config, dst);
            return dst.Emit();
        }

        [Op]
        public static string format(AsmRoutine src, string header, in AsmFormatConfig config)
        {
            var dst = text.buffer();
            dst.AppendLine(header);
            dst.AppendLine(instructions(src, config).Join(Eol));
            return dst.Emit();
        }

        [Op]
        public static void render(AsmRoutine src, in AsmFormatConfig config, ITextBuffer dst)
        {
            var buffer = span<string>(16);
            var header = new ApiCodeBlockHeader(src.Uri, src.DisplaySig.Format(), src.Code, src.TermCode);
            var count = render(header,buffer);
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(buffer,i));
            dst.AppendLine(instructions(src, config).Join(Eol));
        }

        /// <summary>
        /// Formats the instructions in a function
        /// </summary>
        /// <param name="src">The source function</param>
        /// <param name="config">An optional format configuration</param>
        [Op]
        public static ReadOnlySpan<string> instructions(AsmRoutine src, in AsmFormatConfig config)
        {
            var summaries = AsmRoutines.summarize(src);
            var count = summaries.Length;
            if(count == 0)
                return default;
            var dst = span<string>(count);
            for(var i=0u; i< count; i++)
                seek(dst,i) = AsmRender.format(src.BaseAddress, skip(summaries,i), config);
            return dst;
        }

        [MethodImpl(Inline), Op]
        static AsmInlineComment comment(AsmCommentMarker marker, string src)
            => new AsmInlineComment(marker,src);

        static byte render(in ApiCodeBlockHeader src, Span<string> dst)
        {
            const string PageBreak = "#" + CharText.Space + RP.PageBreak160;
            const AsmCommentMarker CommentMarker = AsmCommentMarker.Hash;
            var i = z8;
            seek(dst, i++) = PageBreak;
            seek(dst, i++) = comment(CommentMarker, $"{src.DisplaySig}::{src.Uri}");
            seek(dst, i++) = AsmRender.spanres(src.Uri, src.CodeBlock);
            seek(dst, i++) = AsmRender.hexarray(src.CodeBlock);
            seek(dst, i++) = comment(CommentMarker, string.Concat(nameof(CodeBlock.BaseAddress), RP.spaced(Chars.Eq), src.CodeBlock.BaseAddress));
            seek(dst, i++) = comment(CommentMarker, string.Concat(nameof(src.TermCode), RP.spaced(Chars.Eq), src.TermCode.ToString()));
            seek(dst, i++) = PageBreak;
            return i;
        }
    }
}