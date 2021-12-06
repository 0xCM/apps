//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class GlobalCommands
    {
        [CmdOp("emit-api-comments")]
        protected Outcome EmitApiComments(CmdArgs args)
        {
            var collected = Service(Wf.ApiComments).Collect();
            return true;
        }
    }
}