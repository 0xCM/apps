//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedFields;

    using K = XedRules.FieldKind;

    partial class XedDisasm
    {
        public const string RenderCol2 = FieldRender.Columns;

        public readonly struct FieldEmitter
        {
            readonly HashSet<FieldKind> Exclusions;

            readonly FieldRender Render;

            readonly FS.FilePath Path;

            public FieldEmitter(FS.FilePath dst)
            {
                Path = dst;
                Exclusions = hashset<FieldKind>(K.TZCNT,K.LZCNT);
                Render = XedFields.render();
            }

            public uint EmitFields(Detail doc)
            {
                var buffer = fields();
                var dst = text.buffer();
                ref readonly var data = ref doc.DataFile;
                dst.AppendLineFormat(RenderCol2, "DataSource", doc.Source.Path.ToUri().Format());
                var counter = 0u;
                for(var i=0u; i<data.LineCount; i++)
                {
                    ref readonly var block = ref doc[i];
                    fields(block, ref buffer);

                    dst.AppendLine(RP.PageBreak240);
                    dst.AppendLine(block.Lines.Format());
                    dst.AppendLine(RP.PageBreak100);

                    XedRender.describe(buffer, dst);
                    dst.AppendLine(RP.PageBreak100);

                    var kinds = buffer.Selected;
                    for(var k=0; k<kinds.Length; k++)
                    {
                        ref readonly var kind = ref skip(kinds,k);
                        if(Exclusions.Contains(kind))
                            continue;

                        dst.AppendLineFormat(RenderCol2, kind, Render[kind](buffer.Fields[kind]));
                        counter++;
                    }

                    XedOperands.render(block.Ops.Map(o => o.Spec), dst);
                    dst.AppendLine();
                }

                using var emitter = Path.AsciEmitter();
                emitter.Write(dst.Emit());
                return counter;
            }
        }
    }
}