//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Datasets;

    partial class XedRules
    {
        void EmitLayouts(Index<InstPattern> patterns)
            => EmitLayouts(CalcInstGroups2(patterns));

        public void EmitLayouts(Index<InstGroup> groups)
        {
            var dst = text.buffer();
            var layouts = XedPatterns.layouts(groups);
            var cols = new TableColumns(
                ("PatternId", 10),
                ("Class", 18),
                ("Index", 8),
                ("OpCode", 26),
                ("Fields", 1)
                );

            var buffer = cols.Buffer();
            buffer.EmitHeader(dst);
            for(var i=0; i<layouts.Count; i++)
            {
                var layout = layouts[i];
                buffer.Write(layout.PatternId);
                buffer.Write(layout.Class);
                buffer.Write(layout.Index);
                buffer.Write(layout.OpCode.Format());
                buffer.Write(layout.Format());
                buffer.EmitLine(dst);
            }

            FileEmit(dst.Emit(), layouts.Count, XedPaths.Targets() + FS.file("xed.inst.layouts", FS.Csv), TextEncodingKind.Asci);
        }
    }
}