//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public readonly struct AsmRender
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        static AsmInlineComment comment(AsmCommentMarker marker, string src)
            => new AsmInlineComment(marker,src);

        const AsmCommentMarker CommentMarker = AsmCommentMarker.Hash;

        [Op]
        public static AsmInlineComment spanres(OpUri uri, BinaryCode src)
            => comment(CommentMarker, SpanResFormatter.format(SpanRes.specify(uri, src)));

        [Op]
        public static AsmInlineComment hexarray(BinaryCode src)
            => comment(CommentMarker, Hex.hexarray(src).Format(true));

        [Op]
        public static string format(MemoryAddress @base, in AsmInstructionInfo src, in AsmFormatConfig config)
        {
            var dst = text.buffer();
            render(@base, src, config, dst);
            return dst.ToString();
        }

        const string InstInfoPattern = "{0} | {1,-3} | {2,-32} | ({3}) = {4}";

        [Op]
        public static string format(in AsmOffsetLabel label, in AsmFormInfo src, byte[] encoded)
            => string.Format(InstInfoPattern, label, encoded.Length, encoded.FormatHex(), src.Sig, src.OpCode);

        [Op]
        public static void render(MemoryAddress @base, in AsmInstructionInfo src, in AsmFormatConfig config, ITextBuffer dst)
        {
            const string AbsolutePattern = "{0} {1} {2}";
            const string RelativePattern = "{0} {1}";
            var label = offset(src.Offset, w16);
            var address = @base + src.Offset;
            if(config.EmitLineLabels)
            {
                if(config.AbsoluteLabels)
                    dst.Append(string.Format(AbsolutePattern, address.Format(), label, src.Statement.FormatPadded()));
                else
                    dst.Append(string.Format(RelativePattern, label, src.Statement.FormatPadded()));
            }
            else
            {
                dst.Append(src.Statement.FormatPadded());
            }

            dst.Append(comment(CommentMarker, format(AsmOffsetLabel.define(16, src.Offset), src.AsmForm, src.Encoded)));
        }

        [Op]
        public static string offset(ulong offset, DataWidth width)
            => width switch{
                DataWidth.W8 => ScalarCast.uint8(offset).FormatAsmHex(),
                DataWidth.W16 => ScalarCast.uint16(offset).FormatAsmHex(),
                DataWidth.W32 => ScalarCast.uint32(offset).FormatAsmHex(),
                DataWidth.W64 => offset.FormatAsmHex(),
                _ => EmptyString
            };


        public static string regop<T>(T src)
            where T : unmanaged, IRegOp<T>
        {
            var op = AsmRegs.reg(src.Size, src.RegClassCode, src.Index);
            return op.Name.Format();
        }

        public static void regvals(ReadOnlySpan<CpuIdRow> src, ITextBuffer dst)
        {
            const sbyte ColWidth = 46;
            const byte ColCount = 6;
            var slots = array(RP.pad(0,-ColWidth), RP.pad(1,-ColWidth), RP.pad(2,-ColWidth), RP.pad(3,-ColWidth), RP.pad(4,-ColWidth), RP.pad(5,-ColWidth));
            var pattern = string.Format("{0} | {1} | {2} | {3} | {4} | {5}", slots);
            var header = string.Format(pattern, "eax(in)", "ecx(in)", "eax(out)", "ebx(out)", "ecx(out)", "edx(out)");
            dst.AppendLine(header);
            var count = src.Length;
            for(var i=0; i<count; i++)
                regvals(skip(src,i), dst);
        }

        public static void regvals(in CpuIdRow row, ITextBuffer dst)
        {
            var w = n8;
            // eax(in)
            dst.AppendFormat("{0} [{1}] | ", row.Leaf, row.Leaf.FormatBits(w));
            // ecx(in)
            dst.AppendFormat("{0} [{1}] | ", row.Subleaf, row.Subleaf.FormatBits(w));
            // eax(out)
            dst.AppendFormat("{0} [{1}] | ", row.Eax, row.Eax.FormatBits(w));
            // ebx(out)
            dst.AppendFormat("{0} [{1}] | ", row.Ebx, row.Ebx.FormatBits(w));
            // ecx(out)
            dst.AppendFormat("{0} [{1}] | ", row.Ecx, row.Ecx.FormatBits(w));
            // edx(out)
            dst.AppendFormat("{0} [{1}] ", row.Edx, row.Edx.FormatBits(w));
            dst.AppendLine();
        }
    }
}