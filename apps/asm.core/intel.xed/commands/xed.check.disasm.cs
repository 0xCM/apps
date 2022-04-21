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
    using static XedFields;

    sealed class DTarget : DisasmTarget
    {
        const sbyte Pad = -24;

        const string PaddedSlots = "{0,-24} | {1}";

        readonly ITextEmitter Output;

        readonly IAppService Wf;

        WfExecFlow<FileRef> CurrentFlow;

        public DTarget(IAppService svc)
        {
            Wf = svc;
            Running += OnBegin;
            Ran += OnEnd;
            OpStateComputed += Handle;
            Output = text.buffer();
            ComputingInst += OnBegin;
            ComputedInst += OnEnd;
            FieldsComputed += Handle;
            OpDetailComputed += Handle;
        }

        void OnBegin(uint seq, in Instruction src)
        {
            Output.AppendLine(RP.PageBreak100);
            Output.AppendLineFormat(PaddedSlots, "Seq", seq);
            Output.AppendLineFormat(PaddedSlots, nameof(src.Id), src.Id);
            Output.AppendLineFormat(PaddedSlots, nameof(src.Asm), src.Asm);
        }

        void OnEnd(uint seq, in Instruction src)
        {
            Output.AppendLine();
        }

        void Handle(uint seq, in Fields src)
        {
            var kinds = src.MemberKinds();
            for(var i=0; i<kinds.Length; i++)
                Handle(src[skip(kinds,i)]);
        }

        void Handle(Field src)
        {
            Output.AppendLineFormat(PaddedSlots, src.Kind, Render[src.Kind](src));
        }

        void RunningFlow(FileRef src)
            => CurrentFlow = Wf.WfMsg.Running(src);

        ExecToken RanFlow()
            => Wf.WfMsg.Ran(CurrentFlow);

        void Handle(FieldKind kind, in OperandState src)
        {

        }

        void Handle(uint seq, in OpDetails src)
        {
            Output.AppendLine("Operands");
            DisasmRender.RenderOps(src, Output);
        }

        void Handle(uint seq, in OperandState state, ReadOnlySpan<FieldKind> fields)
        {
            for(var i=0; i<fields.Length; i++)
                Handle(skip(fields,i), state);
        }

        void OnBegin(WsContext context, in FileRef src)
        {
            Output.Clear();
        }

        void OnEnd(DisasmToken src)
        {
            var name = text.left(CurrentFile.Path.FileName.Format(),Chars.Dot);
            var path = Context.Project.Datasets() + FS.folder("xed.disasm") +  FS.file(string.Format("{0}.{1}",name, "xed.disasm.experiment"), FS.Txt);
            Wf.TableOps.FileEmit(Output.Emit(), 0, path, TextEncodingKind.Asci);
        }
    }

    partial class XedCmdProvider
    {
        XedForms XedForms => Service(Wf.XedForms);

        [CmdOp("xed/check/forms")]
        Outcome CheckForms(CmdArgs args)
        {
            //XedForms.EmitTokens();
            var buffer = ByteBlock64.Empty;
            var bv = BitVector64.Zero;
            for(var i=0u; i<64; i++)
                buffer[i] = math.odd(i) ? bit.On : bit.Off;
            bv = Bitfields.pack64x1(buffer.Bytes);
            Write(bv.Format());

            for(var i=0u; i<64; i++)
                buffer[i] = i < 8 ? bit.Off : i < 16 ? bit.On : bit.Off;
            bv = Bitfields.pack64x1(buffer.Bytes);
            Write(bv.Format());

            return true;
        }

        [CmdOp("xed/check/disasm")]
        Outcome EmitBreakdowns(CmdArgs args)
        {
            var context = Context();
            var flow = XedDisasm.flow(context);
            var targets = bag<DTarget>();
            var sources = XedDisasm.sources(context);
            iter(XedDisasm.sources(context), src => {
                var dst = new DTarget(this);
                flow.Run(src,dst);
                targets.Add(dst);
            }, true);

            return true;
        }

        void Drill(WsContext context, in FileRef src)
        {
            var buffer = XedDisasm.fields();
            var doc = XedDisasm.detail(context,src);
            var count = doc.DataFile.LineCount;
            var state = OperandState.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref doc[i];
            }

            var name = text.left(src.Path.FileName.Format(),Chars.Dot);
            var path = context.Project.Datasets() + FS.folder("xed.disasm") +  FS.file(string.Format("{0}.{1}",name, "xed.disasm.ops.pack"), FS.Csv);
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
    }
}