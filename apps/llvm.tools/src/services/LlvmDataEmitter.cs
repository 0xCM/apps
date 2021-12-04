//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;

    using SQ = SymbolicQuery;

    public partial class LlvmDataEmitter : AppService<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
        }
    }

}