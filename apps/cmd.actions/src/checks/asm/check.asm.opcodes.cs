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
        [CmdOp("check/asm/opcodes")]
        Outcome CheckAsmOpCodes(CmdArgs args)
        {
            var src = Sdm.LoadImportedOpcodes();
            var count = src.Count;
            var result = Outcome.Success;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref src[i];
                result = OpCodes.Parse(detail.OpCode, out var opcode);
                if(result)
                {
                    Write(string.Format("{0} | {1,-36} | {2}", detail.Sig, opcode.Format(), opcode.Flags()));
                    // result = CheckEquality(opcode);
                    // if(result.Fail)
                    //     break;
                }
                else
                    break;
            }

            return result;
        }

        Outcome CheckEquality(in AsmOpCode src)
        {
            var count = src.TokenCount;
            var buffer = alloc<AsmOcToken>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = src[i];
            var dst = AsmOpCodes.define(buffer);
            return src.Equals(dst);
        }

    }
}