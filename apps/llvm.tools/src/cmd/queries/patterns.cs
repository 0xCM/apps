//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    using static core;
    partial class LlvmCmd
    {
        [CmdOp("asm-patterns")]
        Outcome patterns(CmdArgs args)
        {
            var result = TableLoader.LoadAsmPatterns(out var patterns);
            if(result.Fail)
                return result;

            var descriptors = TableLoader.LoadAsmIdDescriptors();
            var count = patterns.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                var inst = pattern.Instruction.Format().Trim();
                var format = pattern.ExprFormat.Format().Trim();
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

        ConstLookup<string,uint> LoadAsmIdLookup()
        {
            var asmid = TableLoader.LoadList("AsmId");
            var lu = lookup<string,uint>();
            foreach(var id in asmid)
            {
                var inserted = lu.Include(id.Value.Trim(), id.Key);
                if(!inserted)
                    Warn(string.Format("Duplicate:{0} {1}", id.Value, id.Key));
            }
            return lu.Seal();
        }
    }
}