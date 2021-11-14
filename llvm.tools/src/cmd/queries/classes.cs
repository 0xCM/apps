//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(classes)]
        Outcome Classes(CmdArgs args)
        {
            var result = Outcome.Success;
            var dst = LlvmPaths.TmpFile(classes, FS.Txt);
            using var writer = dst.AsciWriter();
            Db.EmitClassInfo(writer);
            return result;
        }
    }
}