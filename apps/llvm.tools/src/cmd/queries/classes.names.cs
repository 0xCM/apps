//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("classes/names")]
        Outcome ClassNames(CmdArgs args)
            => Flow("classes/names",DataProvider.SelectClassNames().View);
    }
}