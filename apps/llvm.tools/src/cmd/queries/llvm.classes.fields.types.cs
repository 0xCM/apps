//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string ClassFieldTypeQuery = "llvm/classes/fields/types";

        [CmdOp(ClassFieldTypeQuery)]
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

            var sorted = @readonly(types.Array().Sort());

            Flow(ClassFieldTypeQuery,sorted);
            return true;
        }
    }
}