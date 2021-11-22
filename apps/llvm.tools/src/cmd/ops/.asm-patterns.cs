//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static LlvmNames;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp(".asm-patterns")]
        Outcome AsmStrings(CmdArgs args)
        {
            var fields = Db.DefFields();
            var names = Db.SelectList(Lists.X86Inst).Map(x => (x.Value.Text, x)).ToDictionary();
            var count = fields.Length;
            var records = span<LlvmAsmPattern>(names.Count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                ref readonly var name = ref field.RecordName;
                ref readonly var value = ref field.Value;

                if(field.Name != LlvmNames.RecordFields.AsmString)
                    continue;

                if(names.TryGetValue(field.RecordName, out var item))
                {
                    ref var record = ref seek(records, counter++);
                    record.Id = item.Id;
                    record.Name = name.Content;
                    record.Mnemonic = AsmString.mnemonic(value);
                    record.Format = AsmString.format(value);
                }
            }

            var collected = slice(records,0,counter);
            var dst = LlvmPaths.Table<LlvmAsmPattern>();
            TableEmit(@readonly(collected), dst);
            return true;
        }
    }
}