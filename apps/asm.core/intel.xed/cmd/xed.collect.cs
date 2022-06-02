//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("xed/collect")]
        Outcome XedCollect(CmdArgs args)
        {
            Xed.Disasm.Collect(Context());
            return true;
        }
    }
}