//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(defs)]
        Outcome Defs(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = LlvmPaths.TmpFile(defs, FS.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            EmittedFile(emitting, Db.EmitDefInfo(writer));
            return result;
        }
    }
}