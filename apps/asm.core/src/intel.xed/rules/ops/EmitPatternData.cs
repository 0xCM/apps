//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        void EmitPatternData(Index<InstPattern> src)
            => exec(PllExec,
                () => EmitPatternInfo(src),
                () => EmitPatternDetails(src),
                () => EmitPatternOps(src)
                );

        void EmitPatternInfo(Index<InstPattern> src)
            => TableEmit(XedPatterns.describe(src).View, InstPatternInfo.RenderWidths, XedPaths.Table<InstPatternInfo>());

        void EmitPatternDetails(Index<InstPattern> src)
            => EmitPatternDetails(src, XedPaths.DocTarget(XedDocKind.PatternDetail));

        void EmitPatternOps(Index<InstPattern> src)
            => TableEmit(src.SelectMany(x => x.OpInfo).Sort().View, OpInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));
    }
}