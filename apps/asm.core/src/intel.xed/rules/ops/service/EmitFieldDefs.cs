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
            var src = ParseFieldDefs();
            EmitFieldDefs(src);
            return src;
        }

        public FS.FilePath EmitFieldDefs(ReadOnlySpan<XedFieldDef> src)
        {
            var dst = XedPaths.FieldDefsTarget();
            TableEmit(src, XedFieldDef.RenderWidths, dst);
            return dst;
        }
    }
}