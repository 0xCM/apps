//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/asmstrings")]
        void EmitAsmStrings()
            => DataEmitter.Emit(Calcs.CalcAsmStrings(DataProvider.Entities()));
    }
}