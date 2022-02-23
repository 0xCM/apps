//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/check/mem")]
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