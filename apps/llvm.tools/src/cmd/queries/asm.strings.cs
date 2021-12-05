//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("asm/strings")]
        Outcome patterns(CmdArgs args)
        {
            var patterns = DataProvider.SelectAsmPatterns();
            var descriptors = DataProvider.SelectAsmIdDescriptors();
            var count = patterns.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                var inst = pattern.Instruction.Format().Trim();
                var format = pattern.ExprFormat.Format();
                if(descriptors.Find(inst, out var descriptor))
                {
                    Write(string.Format("format({0}:{1}) = '{2}'", descriptor.InstName, descriptor.Id, format));
                }
                else
                {
                    return (false, string.Format("Id for '{0}' not found", inst));
                }

            }
            return true;
        }
    }
}