//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/query/inst")]
        Outcome XedQuery(CmdArgs args)
        {
            Main.QueryCatalog(arg(args,0));
            return true;
        }
    }
}