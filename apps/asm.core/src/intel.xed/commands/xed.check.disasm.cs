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
            for(var i=0; i<files.Count; i++)
            {

                ref readonly var file = ref files[i];
                var blocks = XedDisasm.blocks(file);
                CheckDisasm(blocks);
                var details = Disasm.CalcDisasmDetails(context, file);
                var count = details.Count;
                for(var j=0; j < count; j++)
                {
                    ref readonly var detail = ref details[j];

                }
            }

            //var flags = XedRules.flags(rules);

            return true;
        }

        void CheckDisasm(in DisasmFileBlocks src)
        {
            var name = src.Source.DocName;
            var dst = AppDb.Log("xed", name, FileKind.Log);
            var emitting = EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                {
                    writer.AppendLine();
                    writer.AppendLine();
                }

                ref readonly var block = ref src[i];
                var props = XedDisasm.props2(block);
                writer.AppendLineFormat("{0,-25}{1:D5}", "Instruction",  i);
                writer.AppendLine(RP.PageBreak80);
                for(var j=0; j<props.Count; j++)
                {
                    ref readonly var prop = ref props[j];
                    writer.AppendLineFormat("{0,-24} {1}", prop.Kind, prop.Format());
                    counter++;
                }
            }
            EmittedFile(emitting,counter);
        }

    }
}