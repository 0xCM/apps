//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(def_names)]
        Outcome DefNames(CmdArgs args)
            => Flow(def_names, Db.DefNames());
    }
}
