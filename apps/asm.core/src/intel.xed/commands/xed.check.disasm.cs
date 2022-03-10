//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedDisasm;
    using static XedModels;
    using Asm;

    using K = XedRules.FieldKind;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var receiver = new WsEventReceiver();
            var project = Project();
            var context = Projects.Context(project, receiver);
            var files = context.Files(FileKind.XedRawDisasm);
            AppDb.Logs("xed").Clear();

            FieldFormatter[K.EOSZ] = FieldFormatters.eosz;
            FieldFormatter[K.EASZ] = FieldFormatters.easz;
            FieldFormatter[K.MODE] = FieldFormatters.mode;

            iter(files, file => CheckDisasm(context, XedDisasm.blocks(file)),true);

            return true;
        }

        FieldRender FieldFormatter => Service(FieldRender.create);

        void CheckDisasm(WsContext context, in DisasmFileBlocks src)
        {
            const string FieldPattern = "{0,-24} | {1}";
            var name = src.Source.DocName;
            var fieldrender = FieldFormatter;
            var dst = AppDb.Log("xed", name, FileKind.Log);
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