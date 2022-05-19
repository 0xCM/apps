//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/emit/comments")]
        Outcome EmitApiComments(CmdArgs args)
        {
            EmitApiComments();
            return true;
        }
    }
}