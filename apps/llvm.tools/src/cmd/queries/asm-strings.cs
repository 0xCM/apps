//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmCmd
    {
        [CmdOp("asm-strings")]
        Outcome AsmStrings(CmdArgs args)
        {
            var result = RecordLoader.LoadFields(Datasets.X86DefFields, out var fields);
            if(result.Fail)
                return result;

            var names = RecordLoader.LoadList(Lists.X86Inst).Map(x => x.Value.Text).ToHashSet();

            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                ref readonly var name = ref field.Name;

                if(names.Contains(field.RecordName) && field.Name == LlvmNames.RecordFields.AsmString)
                {
                    Write(field.Format());
                }
            }

            return true;
        }
    }
}