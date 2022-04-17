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
        public void EmitFieldSpecs()
        {
            var cols = new TableColumns(
                ("Seq", 8),
                ("Kind", 22),
                ("Offset", 8),
                ("Size", 8),
                ("DataType", 16),
                ("EffectiveType", 16)
                );
            var dst = text.buffer();
            var buffer = cols.Buffer();
            buffer.EmitHeader(dst);

            ref readonly var specs = ref XedFields.Specs;
            var offset = 0u;
            for(var i=0; i<specs.Count; i++)
            {
                if(i==0)
                    continue;

                var kind = (FieldKind)i;
                ref readonly var spec = ref specs[kind];

                buffer.Write(i-1);
                buffer.Write(spec.Kind);
                buffer.Write(offset);
                buffer.Write(spec.Size.DataSize);
                buffer.Write(spec.Type);
                buffer.Write(spec.EffectiveType);
                buffer.EmitLine(dst);

                offset += (spec.Size.DataSize);
            }

            FileEmit(dst.Emit(), specs.Count, XedPaths.Targets() + FS.file("xed.fields", FS.Csv), TextEncodingKind.Asci);
        }
    }
}