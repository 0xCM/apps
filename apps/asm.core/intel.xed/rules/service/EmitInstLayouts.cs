//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Datasets;

    partial class XedRules
    {
        public void EmitInstLayouts(Index<InstLayout> src)
        {
            var dst = text.buffer();
            var cols = new TableColumns(
                ("PatternId", 10),
                ("Class", 18),
                ("Index", 8),
                ("OpCode", 26),
                ("Fields", 1)
                );

            var buffer = cols.Buffer();
            buffer.EmitHeader(dst);
            for(var i=0; i<src.Count; i++)
            {
                var layout = src[i];
                buffer.Write(layout.PatternId);
                buffer.Write(layout.Class);
                buffer.Write(layout.Index);
                buffer.Write(layout.OpCode.Format());
                buffer.Write(layout.Format());
                buffer.EmitLine(dst);
            }

            FileEmit(dst.Emit(), src.Count, XedPaths.Targets() + FS.file("xed.inst.layouts", FS.Csv), TextEncodingKind.Asci);
        }

        void EmitInstLayouts(Index<InstPattern> src)
            => EmitInstLayouts(CalcInstLayouts(CalcInstGroups(src)));
   }
}