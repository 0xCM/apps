//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Asm.AsmRegOps;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/mem")]
        public Outcome CheckAsmMem(CmdArgs args)
        {
            var result = true;
            var results = AsmCases.check(AsmCases.MemOpCases());
            for(var i=0; i<results.Count; i++)
            {
                ref readonly var r = ref results[i];
                Show(r.Outcome);
                if(r.Outcome.Fail)
                    result = false;

            }

            return result;
        }
    }
}