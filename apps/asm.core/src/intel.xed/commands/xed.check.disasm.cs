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
            iter(files, file => CheckDisasm(context, XedDisasm.blocks(file)),true);
            //var flags = XedRules.flags(rules);

            return true;
        }

        void CheckDisasm(WsContext context, in DisasmFileBlocks src)
        {
            var name = src.Source.DocName;
            var dst = AppDb.Log("xed", name, FileKind.Log);
            var emitting = EmittingFile(dst);
            XedDisasm.CalcSummaryDoc(context, src.Source, out var summaries);
            Require.equal(summaries.RowCount, src.Count);
            var counter = 0u;
            var state = RuleState.Empty;
            var formatter = Tables.formatter<StateFlags>();
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
                var flags = XedRules.flags(state);
                var packed = XedRules.pack(flags);
                writer.AppendLineFormat("{0,-24} | {1}", (Address32)summary.IP, summary.Asm);
                writer.AppendLine(RP.PageBreak80);
                writer.AppendLineFormat("{0,-24} {1}", nameof(summary.Encoded), summary.Encoded);
                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var prop = ref fields[j];
                    writer.AppendLineFormat("{0,-24} {1}", prop.Kind, prop.Format());
                    counter++;
                }

            }
            EmittedFile(emitting,counter);
        }
    }
}