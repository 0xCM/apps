//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp(".mc-docs")]
        Outcome Syntax(CmdArgs args)
        {
            var result = Outcome.Success;

            var docs = Mc.AsmDocs(Project());
            foreach(var doc in docs)
            {
                var path = doc.Path.ToUri();
                var inst = doc.Instructions;
                var lines = doc.SourceLines.Map(x => (x.LineNumber, x.Statement)).ToDictionary();
                var count = inst.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var instruction = ref skip(inst,i);
                    var expr = lines[instruction.Line];
                    var loc = path.LineRef(instruction.Line);

                    Write(string.Format("{0,-8} | {1,-32} | {2,-64} | {3}", instruction.Seq, instruction.Name, expr, loc));
                }
            }

            return result;
        }

    }
}