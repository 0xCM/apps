//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class CheckCmdProvider
    {

        [CmdOp("check/sdm/sigs")]
        Outcome CheckSdmSigs(CmdArgs args)
        {
            var rules = SdmRules.LoadSigProductions();
            var count = rules.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var rule = ref rules[i];
                // var terminals = rule.Target.Terminate();
                // for(var j=0; j<terminals.Count; j++)
                // {
                //     ref readonly var terminal = ref terminals[j];
                //     Write(terminal.Format());
                // }

                Write(rule.Format());
            }
            return true;
        }
    }
}