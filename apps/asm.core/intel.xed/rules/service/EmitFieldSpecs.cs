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
                ("Index", 8),
                ("Pos", 8),
                ("Kind", 22),
                ("Offset", 8),
                ("Size", 8),
                ("DataType", 16),
                ("EffectiveType", 16)
                );
            var dst = text.buffer();
            var buffer = cols.Buffer();
            buffer.EmitHeader(dst);

            ref readonly var specs = ref XedFields.ByIndex;
            var offset = 0u;
            for(var i=0; i<specs.Count; i++)
            {
                if(i==0)
                    continue;

                ref readonly var spec = ref specs[i];

                buffer.Write(i);
                buffer.Write(spec.Pos);
                buffer.Write(spec.Field);
                buffer.Write(offset);
                buffer.Write(spec.FieldSize.DataSize);
                buffer.Write(spec.DataType);
                buffer.Write(spec.DomainType);
                buffer.EmitLine(dst);

                offset += (spec.FieldSize.DataSize);
            }

            FileEmit(dst.Emit(), specs.Count, XedPaths.Targets() + FS.file("xed.fields.indexed", FS.Csv), TextEncodingKind.Asci);
        }
    }
}