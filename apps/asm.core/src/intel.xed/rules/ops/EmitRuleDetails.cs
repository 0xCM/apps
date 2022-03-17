//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        void EmitPatternDetails(Index<InstPattern> src, FS.FilePath path)
        {
            const string LabelPattern = "{0,-16} | {1}";
            var seq = 0u;
            var emitting = EmittingFile(path);
            using var dst = path.AsciWriter();
            for(var j=0; j<src.Count; j++)
            {
                ref readonly var pattern = ref src[j];
                ref readonly var def = ref pattern.InstDef;
                dst.AppendLineFormat(LabelPattern, "Pattern", seq++);
                dst.AppendLineFormat(LabelPattern, "Instruction", def.Seq);
                dst.AppendLineFormat(LabelPattern, nameof(def.Class), def.Class);
                dst.AppendLineFormat(LabelPattern, nameof(def.Form), def.Form);
                dst.AppendLineFormat(LabelPattern, nameof(def.Category), def.Category);
                dst.AppendLineFormat(LabelPattern, nameof(def.Extension), def.Extension);
                dst.AppendLineFormat(LabelPattern, nameof(def.Flags), def.Flags.IsNonEmpty ? def.Flags.Delimit(fence:RenderFence.Embraced) : EmptyString);
                dst.AppendLineFormat(LabelPattern, nameof(pattern.Body), pattern.Body.Delimit(Chars.Space));
                dst.AppendLineFormat(LabelPattern, "Operands", RP.PageBreak80);
                ref readonly var ops = ref pattern.OpSpecs;
                for(byte k=0; k<ops.Count; k++)
                {
                    ref readonly var op = ref ops[k];
                    dst.AppendFormat("{0,-16}", op.Name);
                    dst.AppendFormat(" | {0,-32}", op.Expression);
                    var attribs = op.Attribs;
                    for(var m=0; m<attribs.Count; m++)
                        dst.AppendFormat(" | {0,-16}", attribs[m]);

                    dst.AppendLine();
                }
                dst.AppendLine(RP.PageBreak100);
            }

            EmittedFile(emitting,seq);
        }
    }
}