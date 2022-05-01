//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/layouts")]
        Outcome EmitLayouts(CmdArgs args)
        {
            TableEmit(LayoutCalcs.layouts(CalcPatterns()).View, InstLayout.RenderWidths, XedPaths.Table<InstLayout>());
            return true;
        }
    }
}