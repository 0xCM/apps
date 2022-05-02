//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        public class InstPageFormatter
        {
            public static InstPageFormatter create()
                => new InstPageFormatter();

            public string Format(InstPattern pattern)
                => page(pattern);

            public Index<InstIsaFormat> GroupFormats(Index<InstPattern> src)
            {
                var buffer = bag<InstIsaFormat>();
                iter(src.GroupBy(x => x.Isa.Kind), g => buffer.Add(format(g.Key, g.Array())), AppData.PllExec());
                return buffer.Array().Sort();
            }

            const byte SectionWidth = 140;

            const string InstSep = RP.PageBreak160 + RP.PageBreak20;

            static string FieldTitle = "Fields".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            static string OpsTitle = "Operands".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            const string LabelPattern = "{0,-18}{1}";

            public static string page(InstPattern pattern)
            {
                var emitter = text.emitter();
                emitter.AppendLine(header(pattern));
                emitter.AppendLineFormat(LabelPattern, nameof(pattern.Category), pattern.Category);
                emitter.AppendLineFormat(LabelPattern, "Layout", pattern.Layout.Format());
                emitter.AppendLineFormat(LabelPattern, "Expressions", pattern.Expr.Format());

                emitter.AppendLineFormat(LabelPattern, nameof(pattern.Mode), XedRender.format(pattern.Mode));
                emitter.AppendLineFormat(LabelPattern, nameof(pattern.OpCode), pattern.OpCode);
                if(pattern.InstForm.IsNonEmpty)
                    emitter.AppendLineFormat(LabelPattern, nameof(pattern.InstForm), pattern.InstForm);

                if(pattern.Attributes.IsNonEmpty)
                    emitter.AppendLineFormat(LabelPattern, nameof(pattern.Attributes), XedRender.format(pattern.Attributes, false, Chars.Space));

                if(pattern.Effects.IsNonEmpty)
                    emitter.AppendLineFormat(LabelPattern, nameof(pattern.Effects), XedRender.format(pattern.Effects, false, Chars.Space));

                Index<string> buffer = alloc<string>(128);
                emitter.AppendLine(FieldTitle);
                var fcount = RenderFields(pattern, buffer);
                for(var k=0; k<fcount;k++)
                    emitter.AppendLine(buffer[k]);

                buffer.Clear();

                emitter.AppendLine(OpsTitle);
                var opscount = RenderOps(pattern, buffer);
                for(var k=0; k<opscount;k++)
                    emitter.AppendLine(buffer[k]);

                emitter.AppendLine(InstSep);

                return emitter.Emit();
            }

            static InstIsaFormat format(InstIsa isa, Index<InstPattern> src)
            {
                var counter=0u;
                var dst = text.emitter();
                for(var i=0; i<src.Count; i++)
                    dst.Append(page(src[i]));
                return new (isa, src, dst.Emit(), counter);
            }

            static string header(InstPattern src)
                => string.Format("{0,-18}{1,-18}{2}", src.InstClass, src.Isa, src.InstForm);

            static byte RenderFields(InstPattern src, Span<string> dst)
            {
                const string Pattern = "{0,-2} {1,-14} {2}";
                var count = (byte)src.Fields.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var field = ref src.Fields[j];
                    var fk = XedRender.format(field.Field);
                    if(field.IsLiteral)
                        seek(dst,j) = string.Format(Pattern, j, "Literal", field.Format());
                    else
                    {
                        switch(field.CellKind)
                        {
                            case RuleCellKind.EqExpr:
                            case RuleCellKind.NeqExpr:
                            case RuleCellKind.NontermExpr:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.ToCellExpr());
                            break;
                            case RuleCellKind.NontermCall:
                            {
                                var rule = field.AsNonterm();
                                if(rule.IsNonEmpty)
                                {
                                    var uri = XedPaths.Service.CheckedTableDef(new RuleSig(RuleTableKind.ENC, rule));
                                    if(!uri.Path.Exists)
                                        uri = XedPaths.Service.CheckedTableDef(new RuleSig(RuleTableKind.DEC, rule));

                                    if(uri.Path.Exists)
                                        seek(dst,j) = string.Format(Pattern, j, "Nonterm",  string.Format("{0}::{1}", rule.Format(), uri));
                                    else
                                        seek(dst,j) = string.Format(Pattern, j, "Nonterm",  rule);
                                }
                                else
                                    term.warn(string.Format("There is no rule for nonterminal {0}", rule));

                            }
                            break;
                            case RuleCellKind.SegField:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.ToSegField());
                            break;
                            case RuleCellKind.InstSeg:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.AsInstSeg());
                            break;
                            case RuleCellKind.SegVar:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.AsSegVar());
                            break;
                            default:
                                Errors.Throw(string.Format("Unhandled case: {0}", field.CellKind));
                            break;
                        }
                    }
                }
                return count;
            }

            static byte RenderOps(InstPattern src, Span<string> dst)
            {
                const string RenderPattern = "{0,-2} {1,-14} {2,-4} {3,-4} {4} {5,-88} [{6}]";
                ref readonly var ops = ref src.Ops;
                var count = (byte)ops.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var op = ref ops[j];
                    op.Action(out var action);
                    op.Visibility(out var opvis);
                    if(op.IsNonTerminal)
                        seek(dst,j) = (string.Format(RenderPattern,
                            op.Index,
                            XedRender.format(op.Name),
                            XedRender.format(action),
                            opvis.Code(),
                            XedOperands.descriptor(src.Mode, op),
                            FormatNonterm(op),
                            op.SourceExpr
                            ));
                    else
                        seek(dst,j) = (string.Format(RenderPattern,
                            op.Index,
                            XedRender.format(op.Name),
                            XedRender.format(action),
                            opvis.Code(),
                            XedOperands.descriptor(src.Mode, op),
                            op.IsReg ? FormatRegLit(op) : EmptyString,
                            op.SourceExpr
                            ));
                }

                return count;
            }

            static string FormatRegLit(in PatternOp src)
            {
                var dst = EmptyString;
                if(src.RegLiteral(out var reg))
                    dst = reg.Format();
                return dst;
            }

            static string FormatNonterm(in PatternOp src)
            {
                var dst = EmptyString;
                if(src.Nonterminal(out var nt))
                {
                    var path = XedPaths.Service.TableDef(RuleTableKind.ENC, nt);
                    if(path.IsEmpty)
                        path = XedPaths.Service.TableDef(RuleTableKind.DEC, nt);
                    if(path.IsNonEmpty)
                        dst = string.Format("{0}::{1}", nt, path);
                }
                return dst;
            }
        }
    }
}