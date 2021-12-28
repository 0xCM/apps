//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static core;

    partial class GlobalCommands
    {
        [CmdOp("sdm/import/opcodes")]
        Outcome SdmCodeGen(CmdArgs args)
        {
            var result = Outcome.Success;
            var opcodes = Sdm.ImportOpCodes();
            var count = opcodes.Count;
            var buffer = span<AsmSigOpExpr>(4);
            var sigs = Sdm.Sigs(opcodes);
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var oc = ref opcodes[i];
                ref readonly var sig = ref sigs[i];
                Write(format(oc.OpCode, sig));
            }

            return result;
        }

        static string format(string oc, AsmSigExpr src)
        {
            var mnemonic = src.Mnemonic.Format(MnemonicCase.Lowercase);
            var count = src.OperandCount;
            if(count == 0)
            {
                return string.Format("{0,-48} | {1}()", oc, mnemonic);
            }
            else
            {
                var operands = alloc<AsmSigOpExpr>(src.OperandCount);
                src.Operands(operands);
                return string.Format("{0,-48} | {1}({2})", oc, mnemonic, operands.Delimit(Chars.Comma).Format());
            }
        }
   }
}