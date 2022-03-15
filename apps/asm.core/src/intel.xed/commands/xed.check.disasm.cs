//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    using K = XedRules.FieldKind;

    partial class XedCmdProvider
    {
        FieldRender FieldFormatter => Service(FieldRender.create);

        XedDisasmSvc XedDisasmSvc => Service(Wf.XedDisasm);

        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var actions = new Action[]{CheckDisasm1,CheckDisasm2};
            iter(actions, a => a(), true);
            return true;
        }

        void CheckDisasm2(WsContext context, in FileRef file)
        {
            var details = XedDisasmSvc.CalcDisasmDetails(context,file);
            var dst = AppDb.Log("xed",file.DocName, FileKind.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var counter = 0u;
            foreach(var detail in details)
            {
                var mnemonic = detail.Mnemonic;
                var ops = detail.Operands;
                var count = ops.Count;

                writer.AppendLineFormat("{0,-6} {1}", counter++, mnemonic);
                writer.AppendLine(RP.PageBreak40);

                for(var i=0; i<count; i++)
                {
                    ref readonly var op = ref ops[i];
                    render(op, buffer);
                    writer.AppendLine(buffer.Emit());

                }
                writer.WriteLine();
            }
            EmittedFile(emitting,counter);
        }

        static void render(in DisasmOpDetail src, ITextBuffer dst)
        {
            dst.AppendFormat("{0,-6} {1,-4}", src.Index, XedRender.format(src.OpName));

            var kind = opkind(src.OpName);
            ref readonly var selector = ref src.OpInfo.Selector;
            switch(kind)
            {
                case RuleOpKind.Reg:
                case RuleOpKind.Base:
                case RuleOpKind.Index:
                    if(selector.IsNonEmpty)
                    {
                        dst.AppendFormat(" {0}",selector);
                        dst.AppendFormat("/{0}", XedRender.format(src.Action));

                    }
                break;
                default:
                    dst.AppendFormat(" {0}", XedRender.format(src.Action));
                break;
            }

            ref readonly var width = ref src.OpWidth;

            dst.AppendFormat("/{0}", XedRender.format(width.Code));

            if(width.EType.IsNonEmpty && !width.EType.IsInt)
                dst.AppendFormat("/{0}", src.OpWidth.EType);
            if(!src.OpInfo.Visiblity.IsExplicit)
                dst.AppendFormat("/{0}", src.OpInfo.Visiblity);
            if(src.OpInfo.LookupKind != 0)
                dst.AppendFormat("/{0}", src.OpInfo.LookupKind);
        }

        void CheckDisasm2()
        {
            var context = Projects.Context(Project());
            var files = context.Files(FileKind.XedRawDisasm);
            iter(files, file => CheckDisasm2(context,file),true);

        }

        void CheckDisasm1()
        {
            var project = Project();
            var context = Projects.Context(project);
            var files = context.Files(FileKind.XedRawDisasm);
            AppDb.Logs("xed.props").Clear();
            iter(files, file => CheckDisasm(context, XedDisasm.blocks(file)),true);
        }

        void CheckDisasm(WsContext context, in DisasmFileBlocks src)
        {
            const string FieldPattern = "{0,-24} | {1}";
            var name = src.Source.DocName;
            var fieldrender = FieldFormatter;
            var dst = AppDb.Log("xed.props", name, FileKind.Log);
            var emitting = EmittingFile(dst);
            XedDisasm.CalcSummaryDoc(context, src.Source, out var summaries);
            Require.equal(summaries.RowCount, src.Count);
            var counter = 0u;
            var state = RuleState.Empty;
            using var writer = dst.AsciWriter();
            var formatted = hashset<FieldKind>();
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                {
                    writer.AppendLine();
                    writer.AppendLine();
                }

                state = RuleState.Empty;
                ref readonly var block = ref src[i];
                ref readonly var summary = ref summaries[i];
                var fields = XedDisasm.fields(block);
                var lookup = fields.Map(x => (x.Kind, x)).ToDictionary();
                update(fields, ref state);

                writer.AppendLine((Address32)summary.IP);
                writer.AppendLine(RP.PageBreak80);
                writer.AppendLineFormat(FieldPattern, nameof(summary.Asm), summary.Asm);
                writer.AppendLineFormat(FieldPattern, nameof(summary.Encoded), summary.Encoded);

                if(state.DF32)
                {
                    writer.AppendLineFormat(FieldPattern, K.DF32, fieldrender.Format(lookup[K.DF32]));
                    formatted.Add(K.DF32);
                }
                else if(state.DF64)
                {
                    writer.AppendLineFormat(FieldPattern, K.DF64, fieldrender.Format(lookup[K.DF64]));
                    formatted.Add(K.DF64);
                }

                var positions = XedRules.positions(state);
                if(positions.OpCode >= 0)
                    writer.AppendLineFormat(FieldPattern, K.POS_NOMINAL_OPCODE, positions.OpCode);
                if(positions.ModRm >= 0)
                    writer.AppendLineFormat(FieldPattern, K.POS_MODRM, positions.ModRm);
                if(positions.Sib >= 0)
                    writer.AppendLineFormat(FieldPattern, K.POS_SIB, positions.Sib);
                if(positions.Imm0 >= 0)
                    writer.AppendLineFormat(FieldPattern, K.POS_IMM, positions.Imm0);
                if(positions.Imm1 >= 0)
                    writer.AppendLineFormat(FieldPattern, K.POS_IMM1, positions.Imm1);
                if(positions.Disp >= 0)
                    writer.AppendLineFormat(FieldPattern, K.POS_DISP, positions.Disp);

                formatted.Add(K.POS_NOMINAL_OPCODE);
                formatted.Add(K.POS_MODRM);
                formatted.Add(K.POS_SIB);
                formatted.Add(K.POS_IMM);
                formatted.Add(K.POS_IMM1);
                formatted.Add(K.POS_DISP);

                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var field = ref fields[j];
                    if(!formatted.Contains(field.Kind))
                        writer.AppendLineFormat(FieldPattern, field.Kind, fieldrender.Format(field));
                    counter++;
                }
            }
            EmittedFile(emitting,counter);
        }
    }
}