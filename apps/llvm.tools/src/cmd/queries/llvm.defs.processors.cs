//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string ProcessorQuery = "llvm/defs/processors";

        [CmdOp(ProcessorQuery)]
        Outcome Processors(CmdArgs args)
        {
            var src = DataProvider.SelectEntities(e => e.IsProcessor()).Select(e => e.ToProcessor());
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var p = ref src[i];
                Write(string.Format("{0}: {1}", p.Name, p.Features));
            }

            return true;
        }
    }
}
