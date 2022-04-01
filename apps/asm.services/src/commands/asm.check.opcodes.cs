//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/check/opcodes")]
        Outcome CheckAsmOpCodes(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Sdm.LoadOcDetails();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref src[i];
                ref readonly var input = ref detail.OpCodeText;
                AsmOpCodes.parse(detail.OpCodeText, out var opcode).Require();
                result = CheckEquality(input, opcode);
                if(result.Fail)
                {
                    result = (false, string.Format("Equality check failed for <{0}>", input.Format().Trim()));
                    break;
                }

                Write(string.Format("{0,-6} | {1,-16} | {2,-28} | {3}", detail.OpCodeKey, opcode.OcValue(), opcode, detail.SigText));
            }

            return result;
        }

        static bool CheckEquality(in CharBlock36 input, in AsmOpCode parsed)
            => input.Format().Trim().Equals(parsed.Format());

    }
}