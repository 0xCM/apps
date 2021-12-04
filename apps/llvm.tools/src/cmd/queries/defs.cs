//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/defs")]
        Outcome Defs(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = LlvmPaths.TmpFile("llvm.defs", FS.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            EmittedFile(emitting, DataEmitter.EmitDefInfo(writer));
            return result;
        }
    }
}