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
            using var writer = dst.AsciWriter();
            Db.EmitDefInfo(writer);
            return result;
        }
    }
}