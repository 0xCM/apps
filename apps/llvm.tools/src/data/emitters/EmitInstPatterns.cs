//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataEmitter
    {
        public Index<LlvmInstPattern> EmitInstPatterns()
        {
            var entities = DataProvider.SelectEntities();
            var asmids = DataProvider.SelectAsmIdentifiers();
            var count = entities.Length;
            var dst = list<LlvmInstPattern>();

            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsInstAlias())
                {
                    var alias = entity.ToInstAlias();
                    var str = alias.AsmString;
                    var pattern = new LlvmInstPattern();
                    pattern.AsmId = asmids.AsmId(str.InstName);
                    pattern.InstName = str.InstName;
                    pattern.Mnemonic = str.Mnemonic;
                    pattern.FormatPattern = str.FormatPattern;
                    dst.Add(pattern);
                }
                else if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(inst.isCodeGenOnly || inst.isPseudo)
                        continue;
                    else
                    {
                        var str = inst.AsmString;
                        var pattern = new LlvmInstPattern();
                        pattern.AsmId = asmids.AsmId(str.InstName);
                        pattern.InstName = str.InstName;
                        pattern.Mnemonic = str.Mnemonic;
                        pattern.FormatPattern = str.FormatPattern;
                        dst.Add(pattern);
                    }
                }
            }

            var records = dst.ToArray().Sort();
            TableEmit(@readonly(records), LlvmInstPattern.RenderWidths, LlvmPaths.Table<LlvmInstPattern>());
            return records;
        }
    }
}