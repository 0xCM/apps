//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(class_fields)]
        Outcome ClassFields(CmdArgs args)
            => Flow(class_fields, Db.ClassFields());
    }
}