//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        void EmitPatternDetails()
        {
            EmitPatternDetails(CalcEncInstDefs(), AppDb.XedPath("xed.rules.enc.detail", FileKind.Txt));
            EmitPatternDetails(CalcDecInstDefs(), AppDb.XedPath("xed.rules.dec.detail", FileKind.Txt));
        }

        void EmitPatternDetails(Index<InstDef> defs, FS.FilePath path)
        {
            const string LabelPattern = "{0,-16} | {1}";
            var parser = RuleOpParser.create();
            var result = Outcome.Success;
            var seq = 0u;
            var emitting = EmittingFile(path);
            using var dst = path.AsciWriter();
            for(var i=0; i<defs.Count; i++)
            {
                ref readonly var def = ref defs[i];
                var patterns = def.PatternSpecs;
                ExpandMacros(patterns);
                for(var j=0; j<patterns.Count; j++)
                {
                    ref readonly var pattern = ref patterns[j];
                    dst.AppendLineFormat(LabelPattern, "Pattern", seq++);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Class), def.Class);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Form), def.Form);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Category), def.Category);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Extension), def.Extension);
                    dst.AppendLineFormat(LabelPattern, nameof(def.Flags), def.Flags.IsNonEmpty ? def.Flags.Delimit(fence:RenderFence.Embraced) : EmptyString);
                    dst.AppendLineFormat(LabelPattern, nameof(pattern.Expression), pattern.Expression);
                    dst.AppendLineFormat(LabelPattern, "Operands", RP.PageBreak80);
                    ref readonly var ops = ref pattern.Operands;
                    for(var k=0; k<ops.Count; k++)
                    {
                        ref readonly var op = ref ops[k];
                        dst.AppendFormat("{0,-16}", op.Name);
                        var spec = parser.ParseOp(op.Name, op.Expression);
                        var attribs = spec.Attributes;
                        dst.AppendFormat(" | {0,-32}", op.Expression);

                        for(var m=0; m<attribs.Count; m++)
                            dst.AppendFormat(" | {0,-16}", attribs[m]);

                        dst.AppendLine();
                    }
                    dst.AppendLine(RP.PageBreak100);
                }
            }
            EmittedFile(emitting,seq);
        }
    }
}