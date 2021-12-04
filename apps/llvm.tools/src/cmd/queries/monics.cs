//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("monics")]
        Outcome ShowMnemonics(CmdArgs args)
        {

            return true;
        }
    }
}