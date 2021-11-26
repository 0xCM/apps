//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp(".mc-syntax")]
        Outcome Syntax(CmdArgs args)
        {
            var result = Outcome.Success;

            var docs = Mc.SyntaxSources(Project());
            ref readonly var doc = ref docs[0];
            Write(doc.Path.ToUri());
            iter(doc.Instructions, x => Write(x.Format()));

            //iter(docs, doc => Write(string.Format("{0}: {1} instructions", doc.Path, doc.Instructions.Length)));

            return result;
        }
    }
}