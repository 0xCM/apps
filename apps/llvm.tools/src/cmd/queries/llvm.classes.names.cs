//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string ClassNameQuery = "llvm/classes/names";

        [CmdOp(ClassNameQuery)]
        Outcome ClassNames(CmdArgs args)
            => Flow(ClassNameQuery, DataProvider.SelectClassNames());
    }
}