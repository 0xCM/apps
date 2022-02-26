//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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