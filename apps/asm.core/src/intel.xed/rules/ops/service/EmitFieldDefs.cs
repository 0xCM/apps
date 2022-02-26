//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public Index<XedFieldDef> EmitFieldDefs()
        {
            var src = ParseSourceFieldDefs();
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