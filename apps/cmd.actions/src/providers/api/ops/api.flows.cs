//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        [CmdOp("api/flows")]
        protected Outcome RevealDataFlows(CmdArgs args)
        {
            var src = ApiRuntimeCatalog.DataFlows;
            iter(src, flow => Write(flow.Format()));
            return true;
        }
    }
}