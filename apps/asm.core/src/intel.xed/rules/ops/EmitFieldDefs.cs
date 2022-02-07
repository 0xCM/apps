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
        public Index<FieldDef> EmitFieldDefs()
        {
            var src = ParseSourceFieldDefs();
            EmitFieldDefs(src);
            return src;
        }

        public FS.FilePath EmitFieldDefs(ReadOnlySpan<FieldDef> src)
        {
            var dst = XedPaths.FieldDefsTarget();
            TableEmit(src, FieldDef.RenderWidths, dst);
            return dst;
        }
    }
}