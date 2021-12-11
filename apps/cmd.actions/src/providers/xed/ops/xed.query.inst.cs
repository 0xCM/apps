//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        const string XedQueryInst = "xed/query/inst";

        [CmdOp(XedQueryInst)]
        Outcome XedQuery(CmdArgs args)
        {
            Xed.QueryCatalog(arg(args,0));
            return true;
        }
    }
}