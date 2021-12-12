//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/comments")]
        protected Outcome EmitApiComments(CmdArgs args)
        {
            var collected = ApiComments.Collect();
            return true;
        }
    }
}