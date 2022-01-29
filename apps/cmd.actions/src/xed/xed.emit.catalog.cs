//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/catalog")]
        Outcome EmitXedCat(CmdArgs args)
        {
            Xed.EmitCatalog();
           return true;
        }
    }
}