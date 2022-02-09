//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/sigs")]
        Outcome CheckAsmSigs(CmdArgs args)
        {
            var result = Outcome.Success;
            var opcodes = Sdm.LoadImportedOpcodes();
            var count = opcodes.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var opcode = ref opcodes[i];

                result = AsmSigs.parse(opcode.Sig, out var sig);
                if(result.Fail)
                {
                    Warn(result.Message);
                    continue;
                }

            }


            return result;
        }

    }
}