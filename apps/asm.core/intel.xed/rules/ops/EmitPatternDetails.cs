//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using Asm;

    partial class XedRules
    {
        void EmitPatternDetails(Index<InstPattern> src, FS.FilePath dst)
        {
            src.Sort();
            const string LabelPattern = "{0,-20} | {1}";
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
            {
                ref readonly var pattern = ref src[j];

                writer.AppendLineFormat(LabelPattern, pattern.InstClass.Name, pattern.BodyExpr);
                writer.AppendLineFormat(LabelPattern, nameof(pattern.RawBody), pattern.RawBody);
                writer.AppendLineFormat(LabelPattern, nameof(pattern.Mode), XedRender.format(pattern.Mode));
                writer.AppendLineFormat(LabelPattern, nameof(pattern.OpCode),
                    string.Format("{0}[{1}]:{2}",
                        pattern.OpCode.Class,
                        digits(pattern.OpCode.Kind),
                        AsmOcValue.format(pattern.OpCode.Value))
                        );
                writer.AppendLineFormat(LabelPattern, XedRender.format(pattern.Isa), pattern.InstForm);
                writer.AppendLineFormat(LabelPattern, pattern.Category, XedRender.format(pattern.Attributes));

                if(pattern.Effects.IsNonEmpty)
                    writer.AppendLineFormat(LabelPattern, nameof(pattern.Effects), XedRender.format(pattern.Effects));

                ref readonly var ops = ref pattern.Ops;
                if(ops.Count != 0)
                {
                    writer.AppendLineFormat(LabelPattern, RP.PageBreak20, EmptyString);
                    for(byte k=0; k<ops.Count; k++)
                    {
                        ref readonly var op = ref ops[k];
                        writer.AppendFormat("{0} {1,-18} | {2,-32}", op.Index, op.Name, op.SourceExpr);
                        var attribs = op.Attribs;
                        for(var m=0; m<attribs.Count; m++)
                            writer.AppendFormat(" | {0,-10}", attribs[m]);

                        writer.AppendLine();
                    }
                }

                writer.AppendLine(RP.PageBreak120);
            }

            EmittedFile(emitting, src.Count);
        }
    }
}