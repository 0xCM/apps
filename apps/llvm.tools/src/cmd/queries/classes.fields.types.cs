//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("classes/fields/types")]
        Outcome ShowFieldTypes(CmdArgs args)
        {
            var types = hashset<string>();
            var fields = DataProvider.SelectClassFields();
            var count = fields.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                if(text.contains(field.DataType, "AMDGPU"))
                    continue;

                types.Add(field.DataType);
            }

            var sorted = types.Array().Sort();
            iter(sorted, s => Write(s));

            return true;
        }
    }
}