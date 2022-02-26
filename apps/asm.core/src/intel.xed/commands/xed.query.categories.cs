//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/query/categories")]
        Outcome QueryCategores(CmdArgs args)
        {
            TableEmit(Symbols.syminfo<CategoryKind>().View, SymInfo.RenderWidths, XedQueryOut("xed/query/categories"));
            return true;
        }
    }
}