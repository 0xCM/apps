//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        void Emit(Index<PatternOpCode> src)
        {
            TableEmit(src.View, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());
            EmitIdentities(src);
        }

        void Emit(Index<InstFieldRow> src)
            => TableEmit(src.View, InstFieldRow.RenderWidths, XedPaths.Table<InstFieldRow>());

        void Emit(Index<InstPatternRecord> src)
            => TableEmit(src.View, InstPatternRecord.RenderWidths, XedPaths.Table<InstPatternRecord>());

        void Emit(Index<InstOperandRow> src)
            => TableEmit(src.View, InstOperandRow.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));

        void Emit(Index<InstOpClass> src)
            => TableEmit(src.View, InstOpClass.RenderWidths, XedPaths.Table<InstOpClass>());
    }
}