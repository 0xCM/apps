//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        const string XedOpKindQuery = "xed/query/opkinds";

        [CmdOp(XedOpKindQuery)]
        Outcome QueryOpKinds(CmdArgs args)
        {
            TableEmit(Symbols.syminfo<XedModels.OperandTypeKind>().View, SymInfo.RenderWidths, XedQueryOut(XedOpKindQuery));
            return true;
        }
    }
}