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
        const string EmitInstAction = "llvm/emit/instdefs";

        [CmdOp(EmitInstAction)]
        Outcome EmitInst(CmdArgs args)
        {
            DataEmitter.EmitInstDefs();
            return true;
        }
    }
}