//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public void EmitCellDetail(RuleCells src)
        {
            exec(PllExec,
                () => EmitCellsRaw(src),
                () => EmitCellRecords(src)
                );
        }

        void EmitCellsRaw(RuleCells src)
        {
            var dst = text.emitter();
            var count = CellRender.render(src.Flatten(), dst);
            var data = Require.equal(dst.Emit(), src.Description);
            FileEmit(data, count, XedPaths.RuleTarget("cells.raw", FS.Csv), TextEncodingKind.Asci);
        }

        public void EmitCellRecords(RuleCells src)
            => TableEmit(src.Records.View, RuleCellRecord.RenderWidths, XedPaths.RuleTable<RuleCellRecord>());
    }
}