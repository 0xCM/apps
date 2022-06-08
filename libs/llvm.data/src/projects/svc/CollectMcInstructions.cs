//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectSvc
    {
        public Index<AsmInstructionRow> CollectMcInstructions(WsContext context)
        {
            var project = context.Project;
            var result = Outcome.Success;
            var docs = CollectSyntaxDocs(context);
            var buffer = list<AsmInstructionRow>();
            var counter = 0u;
            foreach(var doc in docs)
            {
                var uri = doc.Path.ToUri();
                var origin = context.Root(doc.Path);
                var fref = context.Ref(doc.Path);
                var instructions = doc.Instructions;
                var srcLines = doc.SourceLines;
                var instLineNumbers = instructions.Keys.ToArray().Sort();
                var count = instLineNumbers.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var number = ref skip(instLineNumbers, i);
                    var instruction = instructions[number];
                    var expr = srcLines[number];
                    var record = new AsmInstructionRow();
                    record.Seq = counter++;
                    record.OriginId = origin.DocId;
                    record.OriginName = origin.DocName;
                    record.DocSeq = instruction.DocSeq;
                    record.AsmName = instruction.AsmName;
                    record.Asm = expr.Statement.Format().Trim();
                    record.Source = uri.LineRef(number);
                    buffer.Add(record);
                }
            }

            var records = buffer.ToArray();
            AppSvc.TableEmit(records, AsmInstructionTable(project.Project));
            return records;
        }
    }
}