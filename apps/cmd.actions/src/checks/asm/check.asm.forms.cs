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
        [CmdOp("check/asm/tokens")]
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

        [CmdOp("check/asm/sigs")]
        Outcome CheckAsmSigs(CmdArgs args)
        {
            var details = Sdm.LoadImportedOpcodes();
            var count = details.Count;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                AsmSigs.parse(detail.Sig, out var sig);

                buffer.Append(sig.Mnemonic.Format());
                if(sig.OpCount != 0)
                {
                    buffer.Append("<");
                    for(var j=0; j<sig.OpCount; j++)
                    {
                        if(j != 0)
                            buffer.Append(", ");

                        buffer.Append(AsmSigs.identify(sig[j]));
                    }
                    buffer.Append(">");
                }

                Write(buffer.Emit());
            }

            return true;
        }
    }
}