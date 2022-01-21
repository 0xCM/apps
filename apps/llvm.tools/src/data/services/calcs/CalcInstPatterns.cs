//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataCalcs
    {
        public Index<LlvmInstPattern> CalcInstPatterns(AsmIdentifiers asmids, ReadOnlySpan<LlvmEntity> entities)
        {
            var count = entities.Length;
            var dst = list<LlvmInstPattern>();

            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                if(entity.IsInstAlias())
                {
                    var alias = entity.ToInstAlias();
                    var str = alias.AsmString;
                    var pattern = new LlvmInstPattern();
                    pattern.AsmId = asmids.AsmId(str.InstName);
                    pattern.InstName = str.InstName;
                    pattern.Mnemonic = str.Mnemonic;
                    pattern.FormatPattern = str.FormatPattern;
                    pattern.SourceData = str.SourceData;
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
                        pattern.SourceData = str.SourceData;
                        dst.Add(pattern);
                    }
                }
            }

            return dst.ToArray().Sort();
        }
    }
}