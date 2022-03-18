//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        void EmitPatternData(Index<InstPattern> src)
            => exec(PllExec,
                () => EmitPatternDetails(src),
                () => EmitPatternOps(src)
                );

        void EmitPatternDetails(Index<InstPattern> src)
            => EmitPatternDetails(src, XedPaths.DocTarget(XedDocKind.PatternDetail));

        void EmitPatternOps(Index<InstPattern> patterns)
            => TableEmit(CalcPatternOps(patterns).View, PatternOpDetail.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));
    }
}