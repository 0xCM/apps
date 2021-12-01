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

            var docs = Mc.SyntaxDocs(Project());
            foreach(var doc in docs)
            {
                Write(doc.Path.ToUri());
                iter(doc.Instructions, x => Write(x.Format()));
            }

            return result;
        }

    }
}