//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedCmdProvider
    {
        const string XedAttribQuery = "xed/query/attribs";

        [CmdOp(XedAttribQuery)]
        Outcome QueryAttribs(CmdArgs args)
        {
            TableEmit(Symbols.syminfo<AttributeKind>().View, SymInfo.RenderWidths, XedQueryOut(XedAttribQuery));
            return true;
        }
    }
}