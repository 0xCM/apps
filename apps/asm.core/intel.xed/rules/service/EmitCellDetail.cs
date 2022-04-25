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
        public void EmitCellDetail(KeyedCells src)
        {
            exec(PllExec,
                () => EmitCellsRaw(src),
                () => EmitCellRecords(src)
                );
        }

        void EmitCellsRaw(KeyedCells src)
        {
            var cells = src.Flatten();
            var dst = text.emitter();
            var count = CellRender.render(cells,dst);
            var data = Require.equal(dst.Emit(), src.Description);
            FileEmit(data, count, XedPaths.RuleTarget("cells.raw", FS.Csv), TextEncodingKind.Asci);
        }

        public void EmitCellRecords(KeyedCells src)
            => TableEmit(CalcCellRecords(src).View, KeyedCellRecord.RenderWidths, XedPaths.RuleTable<KeyedCellRecord>());
    }
}