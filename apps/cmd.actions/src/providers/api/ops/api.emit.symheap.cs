//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/symheap")]
        Outcome EmitSymHeap(CmdArgs args)
        {
            Symbolism.EmitSymHeap();
            return true;
        }
    }
}