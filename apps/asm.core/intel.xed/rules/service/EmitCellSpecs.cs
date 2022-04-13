//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public void EmitCellSpecs(RuleTables rules)
        {
            var dst = text.buffer();
            CellRender.cells(rules,dst);
            FileEmit(dst.Emit(), 1, XedPaths.RuleTargets() + FS.file("xed.rules.cells", FS.Csv), TextEncodingKind.Asci);
        }
    }
}