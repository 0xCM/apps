//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataCalcs
    {
        public Index<AsmPattern> CalcAsmStrings(Index<LlvmEntity> src)
        {
            return data(nameof(AsmPattern), Calc);

            Index<AsmPattern> Calc()
            {
                var count = src.Count;
                var dst = bag<AsmPattern>();
                iter(src, entity => {

                    if(entity.IsInstruction())
                    {
                        var inst = entity.ToInstruction();
                        if(!inst.isCodeGenOnly && !inst.isPseudo)
                            dst.Add(inst.AsmString);
                    }

                }, true);
                return dst.Array().Sort();
            }
        }
    }
}