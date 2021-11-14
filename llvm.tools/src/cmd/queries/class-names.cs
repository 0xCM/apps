//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(class_names)]
        Outcome ClassNames(CmdArgs args)
            => Flow(class_names,Db.ClassNames());
    }
}