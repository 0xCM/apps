//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public Index<XedFieldDef> EmitFieldDefs()
        {
            var src = CalcFieldDefs();
            EmitFieldDefs(src);
            return src;
        }

        public void EmitFieldDefs(ReadOnlySpan<XedFieldDef> src)
            => TableEmit(src, XedFieldDef.RenderWidths, XedPaths.FieldDefsTarget());
    }
}