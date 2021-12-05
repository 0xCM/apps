//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("classes")]
        Outcome Classes(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = LlvmPaths.TmpFile("llvm.classes", FS.Txt);
            var emitting = EmittingFile(dst);

            using var writer = dst.AsciWriter();
            EmittedFile(emitting,DataEmitter.EmitClassInfo(writer));
            return result;
        }
    }
}