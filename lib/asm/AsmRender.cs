//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct AsmRender
    {
        const NumericKind Closure = UnsignedInts;

        public static string asmbyte<T>(T src)
            where T : unmanaged, IAsmByte
                => src.Value().FormatHex(zpad:true, specifier:true, uppercase:true);

        public static string format(in HostAsmRecord src)
            => string.Format("{0} {1,-36} # {2} => {3}",
                        src.BlockOffset,
                        src.Expression,
                        string.Format("({0})<{1}>[{2}] => {3}", src.Sig, src.OpCode, src.Encoded.Size, src.Encoded.Format()),
                        src.Encoded.ToBitString()
                        );

        const AsmCommentMarker CommentMarker = AsmCommentMarker.Hash;

        const string PageBreak = "#" + CharText.Space + RP.PageBreak160;

        [Op]
        public static AsmInlineComment spanres(OpUri uri, BinaryCode src)
            => AsmDocBuilder.comment(CommentMarker, SpanRes.format(SpanRes.specify(uri, src)));

        [Op]
        public static AsmInlineComment hexarray(BinaryCode src)
            => AsmDocBuilder.comment(CommentMarker, Hex.hexarray(src).Format(true));

        [Op]
        public static byte format(in ApiCodeBlockHeader src, Span<string> dst)
        {
            var i = z8;
            seek(dst, i++) = PageBreak;
            seek(dst, i++) = AsmDocBuilder.comment(CommentMarker, $"{src.DisplaySig}::{src.Uri}");
            seek(dst, i++) = spanres(src.Uri, src.CodeBlock);
            seek(dst, i++) = hexarray(src.CodeBlock);
            seek(dst, i++) = AsmDocBuilder.comment(CommentMarker, string.Concat(nameof(src.CodeBlock.BaseAddress), RP.spaced(Chars.Eq), src.CodeBlock.BaseAddress));
            seek(dst, i++) = AsmDocBuilder.comment(CommentMarker, string.Concat(nameof(src.TermCode), RP.spaced(Chars.Eq), src.TermCode.ToString()));
            seek(dst, i++) = PageBreak;
            seek(dst, i++) = AsmDocBuilder.comment(src.Uri.OpId.Name);
            return i;
        }

        [Op]
        public static string format(MemoryAddress @base, in AsmInstructionInfo src, in AsmFormatConfig config)
        {
            var dst = text.buffer();
            render(@base, src, config, dst);
            return dst.ToString();
        }

        [Op]
        public static void render(MemoryAddress @base, in AsmInstructionInfo src, in AsmFormatConfig config, ITextBuffer dst)
        {
            const string AbsolutePattern = "{0} {1} {2}";
            const string RelativePattern = "{0} {1}";
            var label = AsmRender.offset(src.Offset, w16);
            var _label = AsmDocBuilder.label(16, src.Offset);
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

            dst.Append(AsmDocBuilder.comment(CommentMarker, AsmOffsetLabel.format(_label, src.AsmForm, src.Encoded)));
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

        // [Op]
        // public static string format(AsmFormInfo src)
        //     => string.Format("({0})<{1}>", src.Sig, src.OpCode);
        // [Op]
        // public static string format(in AsmCaller src)
        //     => string.Format("{0} {1}", src.Base, src.Identity);

        // [Op]
        // public static string format(in AsmCallee src)
        //     => string.Concat(src.Base.Format(), Colon, Chars.Space, src.Identity);

        [Op]
        public static string format(in AsmCallInfo src)
            => string.Format("{0} -> {2}", src.CallSite, src.Target);

        [Op]
        public static string format(in CallRel32 src)
            => string.Format("{0}:{1} -> {2}", src.ClientAddress, src.TargetDx, src.TargetAddress);

        [Op]
        public static string semantic(in AsmDetailRow row)
        {
            var encoded = row.Encoded.Bytes;
            var ip = row.IP;
            var @base = row.BlockAddress;

            if(row.Mnemonic.Format(MnemonicCase.Lowercase) == "jmp")
            {
                if(JmpRel8.test(encoded))
                    return string.Format("jmp(rel8,{0},{1}) -> {2}",
                        JmpRel8.dx(encoded),
                        JmpRel8.offset(@base, ip, encoded),
                        JmpRel8.target(ip, encoded)
                        );
                else if(JmpRel32.test(encoded))
                    return string.Format("jmp(rel32,{0},{1}) -> {2}",
                        JmpRel32.dx(encoded).FormatMinimal(),
                        JmpRel32.offset(@base, ip, encoded).FormatMinimal(),
                        JmpRel32.target(ip, encoded)
                        );
                else if(Jmp64.test(encoded))
                    return string.Format("jmp({0})", Jmp64.target(encoded));
            }
            return EmptyString;
        }

        public static string regop<T>(T src)
            where T : unmanaged, IRegOp<T>
        {
            var op = AsmRegs.reg(src.WidthCode, src.RegClassCode, src.Index);
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