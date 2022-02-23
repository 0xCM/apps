//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/check/tokens")]
        Outcome CheckAsmTokens(CmdArgs args)
        {
            AsmSigs.parse("adc r16, r16", out var sig);
            AsmOpCodes.parse("11 /r", out var oc1);
            AsmOpCodes.parse("13 /r", out var oc2);
            var count = min(oc1.TokenCount, oc2.TokenCount);
            var token = AsmOcToken.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var ta = ref oc1[i];
                ref readonly var tb = ref oc2[i];
                if(ta.Kind == AsmOcTokenKind.Sep && tb.Kind == AsmOcTokenKind.Sep)
                    continue;

                if(ta != tb)
                {
                    token = tb;
                    break;
                }
            }

            if(AsmOpCodes.diff(oc1,oc2, out token))
            {
                Write(token.Format());
            }

            return true;
        }
    }
}