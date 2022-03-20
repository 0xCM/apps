//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/query/opkinds")]
        Outcome QueryOpKinds(CmdArgs args)
        {
            TableEmit(Symbols.syminfo<FieldKind>().View, SymInfo.RenderWidths, XedQueryOut("xed/query/opkinds"));
            return true;
        }
    }
}