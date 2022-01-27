//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        const string XedCategoryQuery = "xed/query/categories";

        [CmdOp(XedCategoryQuery)]
        Outcome QueryCategores(CmdArgs args)
        {
            TableEmit(Symbols.syminfo<XedModels.CategoryKind>().View, SymInfo.RenderWidths, XedQueryOut(XedCategoryQuery));
            return true;
        }
    }
}