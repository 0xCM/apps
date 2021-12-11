//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/catalog")]
        protected Outcome EmitXedCat(CmdArgs args)
        {
            Xed.EmitCatalog();
           return true;
        }
    }
}