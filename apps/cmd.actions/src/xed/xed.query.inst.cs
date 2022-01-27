//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        const string XedInstQuery = "xed/query/inst";

        [CmdOp(XedInstQuery)]
        Outcome XedQuery(CmdArgs args)
        {
            Xed.QueryCatalog(arg(args,0));
            return true;
        }
    }
}