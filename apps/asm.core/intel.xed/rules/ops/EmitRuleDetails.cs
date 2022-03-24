//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;

    partial class XedRules
    {
        void EmitPatternDetails(Index<InstPattern> src, FS.FilePath dst)
        {
            const string LabelPattern = "{0,-16} | {1}";
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
            {
                ref readonly var pattern = ref src[j];
                ref readonly var def = ref pattern.InstDef;
                writer.AppendLineFormat(LabelPattern, "Pattern", pattern.PatternId);
                writer.AppendLineFormat(LabelPattern, "Instruction", pattern.InstId);
                writer.AppendLineFormat(LabelPattern, nameof(pattern.InstClass), pattern.InstClass);
                writer.AppendLineFormat(LabelPattern, nameof(pattern.InstForm), pattern.InstForm);
                writer.AppendLineFormat(LabelPattern, nameof(pattern.Category), pattern.Category);
                writer.AppendLineFormat(LabelPattern, nameof(def.Extension), def.Extension);
                writer.AppendLineFormat(LabelPattern, nameof(def.FlagEffects), XedRender.format(def.FlagEffects));
                writer.AppendLineFormat(LabelPattern, nameof(pattern.RawBody), pattern.RawBody);
                writer.AppendLineFormat(LabelPattern, nameof(pattern.BodyExpr), pattern.BodyExpr);
                writer.AppendLineFormat(LabelPattern, nameof(pattern.OpCode), pattern.OpCode);
                writer.AppendLineFormat(LabelPattern, "Operands", RP.PageBreak80);
                ref readonly var ops = ref pattern.OpSpecs;
                for(byte k=0; k<ops.Count; k++)
                {
                    ref readonly var op = ref ops[k];
                    writer.AppendFormat("{0,-16}", op.Name);
                    writer.AppendFormat(" | {0,-32}", op.Expression);
                    var attribs = op.Attribs;
                    for(var m=0; m<attribs.Count; m++)
                        writer.AppendFormat(" | {0,-16}", attribs[m]);

                    writer.AppendLine();
                }
                writer.AppendLine(RP.PageBreak100);
            }

            EmittedFile(emitting, src.Count);
        }
    }
}