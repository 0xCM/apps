//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/defs")]
        Outcome Defs(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = LlvmPaths.QueryResult(FS.file("llvm.defs", FS.Txt));
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            EmittedFile(emitting, DataEmitter.EmitDefMap(writer));
            return result;
        }
    }
}