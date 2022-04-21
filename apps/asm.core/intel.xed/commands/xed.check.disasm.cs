//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedDisasm;
    using static XedRules;
    using static XedModels;

    partial class XTend
    {
        public static string Delimit<T>(this ReadOnlySpan<T> src, string sep, short pad = 0)
        {
            var dst = text.buffer();
            var slot = RP.slot(0,pad);

            for(var i=0; i<src.Length; i++)
            {
                if(i != 0)
                    dst.Append(sep);

                dst.AppendFormat(slot, skip(src,i));
            }
            return dst.Emit();
        }

        public static string Delimit<T>(this Span<T> src, string sep, short pad = 0)
            => (@readonly(src)).Delimit(sep,pad);

        public static string Delimit<T>(this T[] src, string sep, short pad = 0)
            => (@readonly(src)).Delimit(sep,pad);

        public static string Delimit<T>(this Index<T> src, string sep, short pad = 0)
            => (src.View).Delimit(sep,pad);
    }


    partial class XedCmdProvider
    {
        XedForms XedForms => Service(Wf.XedForms);

        [CmdOp("xed/check/forms")]
        Outcome CheckForms(CmdArgs args)
        {
            // var parts = FormParser.parts();
            // iteri(parts, (i,part) => Write(string.Format("{0,-3} | {1}", i, part)));
            //var tokens = FormTokens.
            // var tokens = XedForms.tokens();
            // iteri(tokens, (i,t) => Write(string.Format("{0,-6} | {1,-12} | {2}", i, t.Kind, t.Format())));

            XedForms.EmitTokens();
            return true;
        }

        [CmdOp("xed/check/disasm")]
        Outcome EmitBreakdowns(CmdArgs args)
        {
            var context = Context();
            var sources = XedDisasm.sources(context);
            var patterns = Xed.Rules.CalcInstPatterns();
            iter(sources, src => Drill(context,src),true);
            return true;
        }

        void Drill(WsContext context, in FileRef src)
        {
            var buffer = XedDisasm.fields();
            var doc = XedDisasm.detail(context,src);
            var count = doc.DataFile.LineCount;
            var dst = alloc<OperandPack>(count);
            for(var i=0; i<count; i++)
            {
                XedDisasm.fields(doc[i], ref buffer);
                seek(dst,i) = Pack(buffer);
            }

            const byte BitStateCount = 52;
            var output = text.buffer();
            ref readonly var positioned = ref XedFields.ByPosition;
            for(var i=0; i<BitStateCount; i++)
                output.AppendLineFormat("{0,-24} | {1}", positioned[i].Field, positioned[i].Pos);
            output.AppendLine(RP.PageBreak120);

            var name = text.left(src.Path.FileName.Format(),Chars.Dot);
            var path = context.Project.Datasets() + FS.folder("xed.disasm") +  FS.file(string.Format("{0}.{1}",name, "xed.disasm.ops.pack"), FS.Csv);

            FormatRows(dst, OperandPack.RenderWidths, output, RecordFormatKind.KeyValuePairs);
            var emitting = EmittingTable<OperandPack>(path);
            using var writer = path.AsciEmitter();
            writer.WriteLine(output.Emit());
            EmittedTable(emitting, count, path);
        }


        protected void TableEmit<T>(T[] src, ReadOnlySpan<byte> widths, FS.FilePath dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(src), widths, dst, fk, encoding);

        protected void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            using var emitter = dst.AsciEmitter();
            TableEmit(src,widths, emitter,fk,encoding);
            EmittedTable(emitting, src.Length, dst);
        }

        protected void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ITextEmitter dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
        {
            var formatter = Tables.formatter<T>(widths,fk:fk);
            var buffer = text.buffer();
            dst.AppendLine(formatter.FormatHeader());

            for(var i=0; i<src.Length; i++)
            {
                ref readonly var row = ref skip(src,i);
                if(i != src.Length - 1)
                    dst.AppendLine(formatter.Format(row));
                else
                    dst.Append(formatter.Format(row));
            }
        }

        protected void FormatRows<T>(T[] src, ReadOnlySpan<byte> widths, ITextEmitter dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(src), widths, dst, fk, encoding);

        Index<FieldKind> FieldKinds = alloc<FieldKind>(128);

        OperandPack Pack(in FieldBuffer src)
        {
            const byte BitStateCount = 52;
            ref readonly var state = ref @as<OperandState,bit>(src.State);

            var bits = alloc<byte>(64);
            var bv0 = BitVector64.Zero;
            for(var i=z8; i<BitStateCount; i++)
            {
                bits[i] = skip(state,i);
                bv0[i] = skip(state,i);

            }

            //BitVector64 bv1  = Bitfields.pack64x1(bits);
            var fields = FieldSet.create(bv0);
            var count = fields.Members(FieldKinds.Edit);
            var names = slice(FieldKinds.View, 0, count).Select(x => XedRender.format(x)).Delimit(" | ", pad:-24);
            var dst = OperandPack.Empty;
            dst.Names = names;
            dst.Statement = src.AsmInfo.Asm;
            dst.Bits = bv0;
            dst.Id = src.Summary.InstructionId;
            return dst;
        }

        [Record(TableId)]
        public struct OperandPack
        {
            public const string TableId = "xed.ops.pack";

            public InstructionId Id;

            public asci64 Statement;

            public BitVector64 Bits;

            public string Names;

            public static OperandPack Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[]{16,16,16,16};
        }
    }
}