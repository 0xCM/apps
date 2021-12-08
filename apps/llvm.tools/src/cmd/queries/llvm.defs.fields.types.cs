//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmCmd
    {
        const string DefFieldTypeQuery = "llvm/defs/fields/types";

        [CmdOp(DefFieldTypeQuery)]
        Outcome QueryDefFieldTypes(CmdArgs args)
        {
            Flow(DefFieldTypeQuery, DataProvider.SelectDistinctFieldTypes(DataProvider.SelectDefFields()));
            return true;
        }
    }
}