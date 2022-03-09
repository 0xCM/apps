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

            FieldFormatter[FieldKind.EOSZ] = FieldFormatters.eosz;
            FieldFormatter[FieldKind.EASZ] = FieldFormatters.easz;
            FieldFormatter[FieldKind.MODE] = FieldFormatters.mode;

            iter(files, file => CheckDisasm(context, XedDisasm.blocks(file)),true);
            //var flags = XedRules.flags(rules);

            return true;
        }

        FieldRender FieldFormatter => Service(FieldRender.create);

        void CheckDisasm(WsContext context, in DisasmFileBlocks src)
        {
            var name = src.Source.DocName;
            var fieldrender = FieldFormatter;
            var dst = AppDb.Log("xed", name, FileKind.Log);
            var emitting = EmittingFile(dst);
            XedDisasm.CalcSummaryDoc(context, src.Source, out var summaries);
            Require.equal(summaries.RowCount, src.Count);
            var counter = 0u;
            var state = RuleState.Empty;
            using var writer = dst.AsciWriter();
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
                update(fields, ref state);
                ref readonly var flags = ref state.Flags;

                writer.AppendLine((Address32)summary.IP);
                writer.AppendLine(RP.PageBreak80);
                writer.AppendLineFormat("{0,-24} {1}", nameof(summary.Asm), summary.Asm);
                writer.AppendLineFormat("{0,-24} {1}", nameof(summary.Encoded), summary.Encoded);

                var positions = XedRules.positions(state);
                if(positions.OpCode >= 0)
                    writer.AppendLineFormat("{0,-24} {1}", FieldKind.POS_NOMINAL_OPCODE, positions.OpCode);
                if(positions.ModRm >= 0)
                    writer.AppendLineFormat("{0,-24} {1}", FieldKind.POS_MODRM, positions.ModRm);
                if(positions.Sib >= 0)
                    writer.AppendLineFormat("{0,-24} {1}", FieldKind.POS_SIB, positions.Sib);
                if(positions.Imm0 >= 0)
                    writer.AppendLineFormat("{0,-24} {1}", FieldKind.POS_IMM, positions.Imm0);
                if(positions.Imm1 >= 0)
                    writer.AppendLineFormat("{0,-24} {1}", FieldKind.POS_IMM1, positions.Imm1);
                if(positions.Disp >= 0)
                    writer.AppendLineFormat("{0,-24} {1}", FieldKind.POS_DISP, positions.Disp);

                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var prop = ref fields[j];
                    if(!XedRules.ispos(prop.Kind))
                        writer.AppendLineFormat("{0,-24} {1}", prop.Kind, fieldrender.Format(prop));
                    counter++;
                }
            }
            EmittedFile(emitting,counter);
        }

    }
}