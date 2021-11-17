//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(classnames)]
        Outcome ClassNames(CmdArgs args)
            => Flow(classnames,Db.ClassNames());
    }
}