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