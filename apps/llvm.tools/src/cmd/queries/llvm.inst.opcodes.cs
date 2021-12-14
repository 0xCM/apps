//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string OpCodeQuery = "llvm/asm/opcodes";

        [CmdOp(OpCodeQuery)]
        Outcome QueryOpCodes(CmdArgs args)
        {
            var records = Distiller.ToRecords(DataProvider.SelectOpCodeMap());
            var dst = LlvmPaths.Table<LlvmAsmOpCode>();
            TableEmit(records.View, dst);
            return true;
        }
    }
}