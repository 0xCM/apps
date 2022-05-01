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
                () => Emit(src.Records.View)
                );
        }

        void EmitCellsRaw(RuleCells src)
        {
            var dst = text.emitter();
            var count = CellRender.Tables.render(src.Flatten(), dst);
            var data = Require.equal(dst.Emit(), src.Description);
            FileEmit(data, count, XedPaths.RuleTarget("cells.raw", FS.Csv), TextEncodingKind.Asci);
        }
    }
}