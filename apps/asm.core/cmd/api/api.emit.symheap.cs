//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("api/emit/symheap")]
        Outcome EmitSymHeap(CmdArgs args)
        {
            ApiSvc.EmitSymHeap();
            return true;
        }
    }
}