//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string AsmStringQuery = "llvm/asm/strings";

        [CmdOp(AsmStringQuery)]
        Outcome patterns(CmdArgs args)
        {
            var patterns = DataProvider.SelectAsmPatterns();
            var descriptors = DataProvider.SelectAsmIdDefs();
            var count = patterns.Count;
            var specs = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                var inst = pattern.Instruction.Format().Trim();
                var format = pattern.ExprFormat.Format();
                if(descriptors.Find(inst, out var descriptor))
                    specs.Add(string.Format("format({0}:{1}) = '{2}'", descriptor.InstName, descriptor.Id, format));
                else
                    return (false, string.Format("Id for '{0}' not found", inst));
            }

            Flow(AsmStringQuery,specs.ViewDeposited());

            return true;
        }
    }
}