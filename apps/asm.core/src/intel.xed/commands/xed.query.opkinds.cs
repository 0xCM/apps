//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedCmdProvider
    {
        const string XedOpKindQuery = "xed/query/opkinds";

        [CmdOp(XedOpKindQuery)]
        Outcome QueryOpKinds(CmdArgs args)
        {
            TableEmit(Symbols.syminfo<XedOpKind>().View, SymInfo.RenderWidths, XedQueryOut(XedOpKindQuery));
            return true;
        }
    }
}