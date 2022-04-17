//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/gen")]
        Outcome XedGen(CmdArgs args)
        {
            // var docs = XedDisasm.docs(Context());
            // var src = XedDisasm.opclasses(docs);
            // TableEmit(src.View, InstOpClass.RenderWidths, XedPaths.Table<InstOpClass>(".disasm"));

            return true;
        }

    }
}