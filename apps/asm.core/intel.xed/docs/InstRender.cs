//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public class InstRender
        {
            const byte SectionWidth = 140;

            public const string LabelPattern = "{0,-18}{1}";

            const string InstSep = RP.PageBreak160 + RP.PageBreak20;

            public static readonly string FieldsHeader = "Fields".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            public static readonly string OpsHeader = "Operands".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            public static byte operands(InstPattern src, Span<string> dst, bool title = true)
            {
                const string RenderPattern = "{0,-2} {1,-14} {2,-4} {3,-4} {4} {5,-88} [{6}]";
                var k=z8;
                if(title)
                    seek(dst,k++) = OpsHeader;

                ref readonly var ops = ref src.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    op.Action(out var action);
                    op.Visibility(out var opvis);
                    if(op.IsNonTerminal)
                    {
                        op.Nonterminal(out var nt);
                        var uri = XedPaths.Service.CheckedTableDef(nt, true, out var sig);
                        seek(dst,k++) = (string.Format(RenderPattern,
                            op.Index,
                            XedRender.format(op.Name),
                            XedRender.format(action),
                            opvis.Code(),
                            XedOperands.descriptor(src.Mode, op),
                            string.Format("{0}::{1}", nt, uri),
                            op.SourceExpr
                            ));
                    }
                    else
                        seek(dst,k++) = (string.Format(RenderPattern,
                            op.Index,
                            XedRender.format(op.Name),
                            XedRender.format(action),
                            opvis.Code(),
                            XedOperands.descriptor(src.Mode, op),
                            op.IsReg ? FormatRegLit(op) : EmptyString,
                            op.SourceExpr
                            ));
                }

                return k;
            }

            public static byte fields(InstPattern src, Span<string> dst, bool title = true)
            {
                const string Pattern = "{0,-2} {1,-14} {2}";

                var k=z8;
                if(title)
                    seek(dst,k++) = FieldsHeader;

                for(var j=0; j<src.Fields.Count; j++)
                {
                    ref readonly var field = ref src.Fields[j];
                    var fk = XedRender.format(field.Field);
                    if(field.IsLiteral)
                        seek(dst,k++) = string.Format(Pattern, j, "Literal", field.Format());
                    else
                    {
                        switch(field.CellKind)
                        {
                            case RuleCellKind.EqExpr:
                            case RuleCellKind.NeqExpr:
                            case RuleCellKind.NontermExpr:
                                seek(dst,k++) = string.Format(Pattern, j, fk, field.ToCellExpr());
                            break;
                            case RuleCellKind.NontermCall:
                            {
                                var rule = field.AsNonterm();
                                if(rule.IsNonEmpty)
                                {
                                    var uri = XedPaths.Service.CheckedTableDef(rule, true, out var sig);
                                    seek(dst,k++) = string.Format(Pattern, j, "Nonterm",  string.Format("{0}::{1}", rule.Format(), uri));
                                }
                                else
                                    term.warn(string.Format("There is no rule for nonterminal {0}", rule));

                            }
                            break;
                            case RuleCellKind.SegField:
                                seek(dst,k++) = string.Format(Pattern, j, fk, field.ToSegField());
                            break;
                            case RuleCellKind.InstSeg:
                                seek(dst,k++) = string.Format(Pattern, j, fk, field.AsInstSeg());
                            break;
                            case RuleCellKind.SegVar:
                                seek(dst,k++) = string.Format(Pattern, j, fk, field.AsSegVar());
                            break;
                            default:
                                Errors.Throw(string.Format("Unhandled case: {0}", field.CellKind));
                            break;
                        }
                    }
                }
                return k;
            }

            static string FormatRegLit(in PatternOp src)
            {
                var dst = EmptyString;
                if(src.RegLiteral(out var reg))
                    dst = reg.Format();
                return dst;
            }
        }
    }
}