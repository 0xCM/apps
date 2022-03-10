//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class XedRules
    {
        static bool attrib(ReadOnlySpan<RuleOpAttrib> src, RuleOpClass kind, out RuleOpAttrib dst)
        {
            var result = false;
            dst = RuleOpAttrib.Empty;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var a = ref skip(src,i);
                if(a.Kind == kind)
                {
                    dst = a;
                    result = true;
                    break;
                }
            }
            return result;
        }

        void CalcPatternOps(uint id, in InstPatternSpec pattern, List<PatternOpDetail> dst)
        {
            ref readonly var ops = ref pattern.Operands;
            var parser = RuleOpParser.create();
            for(byte k=0; k<ops.Count; k++)
            {
                ref readonly var op = ref ops[k];
                var detail = PatternOpDetail.Empty;

                var spec = parser.ParseOp(op.Name, op.Expression);
                var attribs = spec.Attributes.Sort();

                detail.Pattern = id;
                detail.OpIndex = k;
                detail.Name = spec.Name;
                detail.Kind = spec.Kind;
                detail.Expression = op.Expression;
                detail.Mnemonic = pattern.Mnemonic;

                if(attrib(attribs, RuleOpClass.Action, out var action))
                    detail.Action = action;
                if(attrib(attribs, RuleOpClass.OpWidth, out var width))
                    detail.Width = width;
                if(attrib(attribs, RuleOpClass.ElementType, out var et))
                    detail.EType = et;
                if(attrib(attribs, RuleOpClass.EncGroup, out var encgroup))
                    detail.EncGroup = encgroup;
                if(attrib(attribs, RuleOpClass.RegLiteral, out var reglit))
                {
                    detail.RegLit = reglit;
                    //detail.OpWidth = XedModels.width(reglit.AsRegLiteral());
                }
                if(attrib(attribs, RuleOpClass.Modifier, out var mod))
                    detail.Modifier = mod;
                if(attrib(attribs, RuleOpClass.Visibility, out var visib))
                    detail.Visibility = visib;

                dst.Add(detail);
            }
        }

        void EmitPatternDetails(Index<InstDef> defs, FS.FilePath detailpath, FS.FilePath opspath)
        {
            const string LabelPattern = "{0,-16} | {1}";
            var parser = RuleOpParser.create();
            var result = Outcome.Success;
            var seq = 0u;
            var emitting = EmittingFile(detailpath);
            var opsbuffer = list<PatternOpDetail>();
            using var dst = detailpath.AsciWriter();
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

                    CalcPatternOps(seq, pattern, opsbuffer);
                }
            }
            EmittedFile(emitting,seq);

            TableEmit(opsbuffer.ViewDeposited(), PatternOpDetail.RenderWidths, opspath);
        }
    }
}