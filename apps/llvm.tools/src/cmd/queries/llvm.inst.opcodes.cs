//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string OpCodeQuery = "llvm/inst/opcodes";

        [CmdOp(OpCodeQuery)]
        Outcome QueryOpCodes(CmdArgs args)
        {
            var instructions = DataProvider.SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
            var opcodes = Distiller.DistillOpCodes(instructions);
            var records = Distiller.ToRecords(opcodes);
            var dst = LlvmPaths.Table<LlvmInstOpCode>();
            TableEmit(records.View, dst);
            return true;
        }
    }
}