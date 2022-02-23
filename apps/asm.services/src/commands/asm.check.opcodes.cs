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
        [CmdOp("asm/check/opcodes")]
        Outcome CheckAsmOpCodes(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Sdm.LoadImportedOpcodes();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref src[i];
                ref readonly var input = ref detail.OpCode;
                var x = input.Format().Trim();
                result = OpCodes.Parse(input, out var opcode);
                if(result.Fail)
                {
                    result = (false, string.Format("Unable to parse opcode from <{0}>", x));
                    break;
                }

                result = CheckEquality(input, opcode);
                if(result.Fail)
                {
                    result = (false, string.Format("Equality check failed for <{0}>", x));
                    break;
                }

                Write(string.Format("{0,-6} | {1} | {2}", detail.OpCodeKey, detail.Sig, opcode));
            }

            return result;
        }

        static bool CheckEquality(in CharBlock36 input, in AsmOpCode parsed)
        {
            var x = input.Format().Trim();
            var y = parsed.Format();
            return x.Equals(y);
        }
    }
}