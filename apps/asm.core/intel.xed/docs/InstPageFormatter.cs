//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using Asm;

    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        public class InstPageFormatter
        {
            public static InstPageFormatter create(RuleTables tables)
                => new InstPageFormatter(tables);

            public static Index<InstIsaFormat> FormatGroups(RuleTables tables, Index<InstPattern> src)
            {
                var buffer = bag<InstIsaFormat>();
                iter(src.GroupBy(x => x.Isa.Kind), g => buffer.Add(FormatGroup(tables, g.Key, g.Array())), AppData.PllExec());
                return buffer.Array().Sort();
            }

            static InstIsaFormat FormatGroup(RuleTables tables, InstIsa isa, Index<InstPattern> src)
                => create(tables).FormatGroup(isa,src);

            public static string opwidth(MachineMode mode, in PatternOp src)
            {
                const string RenderPattern = "{0,-6} {1,-3} {2,-10} {3,-12}";
                src.ElementType(out var et);
                src.WidthCode(out var w);
                var bw = XedWidths.width(mode,w).Bits;
                var wi = XedWidths.describe(w);
                if(XedPatterns.reglit(src, out Register reg))
                    bw = XedPatterns.bitwidth(reg);

                var seg = EmptyString;
                if(wi.SegType.CellCount > 1)
                {
                    var indicator = EmptyString;
                    if(et.Indicator != 0)
                        indicator = ((char)et.Indicator).ToString();
                    seg = string.Format("{0}x{1}{2}x{3}n", wi.SegType.DataWidth,  wi.SegType.CellWidth, indicator, wi.SegType.CellCount);
                }

                var _bw = bw.ToString();
                if(src.Nonterminal(out var nt))
                {
                    if(GprWidth.widths(nt, out var gpr))
                        _bw = gpr.Format();
                }

                return string.Format(RenderPattern, XedRender.format(w), et, _bw, seg);
            }

            const byte SectionWidth = 140;

            const byte InstWidth = 180;

            const string InstSep = RP.PageBreak160 + RP.PageBreak20;

            static string FieldTitle = "Fields".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            static string OpsTitle = "Operands".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            const string LabelPattern = "{0,-18}{1}";

            readonly RuleTables Tables;

            readonly ITextBuffer Dst;

            readonly Index<string> Buffer;

            uint Counter;

            [MethodImpl(Inline)]
            public InstPageFormatter(RuleTables tables)
            {
                Tables = tables;
                Dst = text.buffer();
                Buffer = alloc<string>(42);
                Counter = 0;
            }

            void AppendLine(string src)
            {
                Dst.AppendLine(src);
                Counter++;
            }

            void AppendLineFormat(string src, params object[] args)
            {
                Dst.AppendLineFormat(src, args);
                Counter++;
            }

            string Emit()
                => Dst.Emit();

            public string Format(InstPattern pattern)
            {
                Render(pattern);
                return Emit();
            }

            void Render(InstPattern pattern)
            {
                AppendLine(FormatInstHeader(pattern));
                AppendLineFormat(LabelPattern, nameof(pattern.Category), pattern.Category);
                AppendLineFormat(LabelPattern, "Layout", pattern.Layout.Format());
                AppendLineFormat(LabelPattern, "Expressions", pattern.Expr.Format());

                AppendLineFormat(LabelPattern, nameof(pattern.Mode), XedRender.format(pattern.Mode));
                AppendLineFormat(LabelPattern, nameof(pattern.OpCode), string.Format("{0,-8} {1}", pattern.OpCode.Kind, AsmOcValue.format(pattern.OpCode.Value)));
                if(pattern.InstForm.IsNonEmpty)
                    AppendLineFormat(LabelPattern, nameof(pattern.InstForm), pattern.InstForm);

                if(pattern.Attributes.IsNonEmpty)
                    AppendLineFormat(LabelPattern, nameof(pattern.Attributes), XedRender.format(pattern.Attributes, false, Chars.Space));

                if(pattern.Effects.IsNonEmpty)
                    AppendLineFormat(LabelPattern, nameof(pattern.Effects), XedRender.format(pattern.Effects, false, Chars.Space));

                AppendLine(FieldTitle);
                var fcount = RenderFields(pattern, Buffer);
                for(var k=0; k<fcount;k++)
                    AppendLine(Buffer[k]);

                AppendLine(OpsTitle);
                var opscount = RenderOps(pattern, Buffer);
                for(var k=0; k<opscount;k++)
                    AppendLine(Buffer[k]);

                AppendLine(InstSep);
            }

            public InstIsaFormat FormatGroup(InstIsa isa, Index<InstPattern> src)
            {
                Counter=0u;
                Dst.Clear();

                for(var i=0; i<src.Count; i++)
                    Render(src[i]);
                return new (isa, src, Emit(), Counter);
            }

            public string FormatInstHeader(InstPattern src)
                => string.Format("{0,-18}{1,-18}{2}", src.InstClass, src.Isa, src.InstForm);

            byte RenderFields(InstPattern src, Span<string> dst)
            {
                const string Pattern = "{0,-2} {1,-14} {2}";
                var count = (byte)src.Fields.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var field = ref src.Fields[j];
                    var fk = XedRender.format(field.FieldKind);
                    if(field.IsLiteral)
                        seek(dst,j) = string.Format(Pattern, j, "Literal", field.Format());
                    else
                    {
                        switch(field.DataKind)
                        {
                            case InstFieldKind.Expr:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.ToFieldExpr());
                                break;
                            case InstFieldKind.Nonterm:
                            {
                                var nt = field.AsNonterminal();
                                var path = Tables.FindTablePath(nt);
                                seek(dst,j) = string.Format(Pattern, j, "Nonterm",  string.Format("{0}::{1}", XedRender.format(nt), path));
                            }
                            break;
                            case InstFieldKind.Seg:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.AsSegField());
                            break;
                            default:
                                Errors.Throw(string.Format("Unhandled case: {0}", field.DataKind));
                            break;
                        }
                    }
                }
                return count;
            }


            byte RenderOps(InstPattern pattern, Span<string> dst)
            {
                const string RenderPattern = "{0,-2} {1,-14} {2,-4} {3,-4} {4} {5,-88} [{6}]";
                ref readonly var ops = ref pattern.Ops;
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
                            opwidth(pattern.Mode, op),
                            FormatNonterm(op),
                            op.SourceExpr
                            ));
                    else
                        seek(dst,j) = (string.Format(RenderPattern,
                            op.Index,
                            XedRender.format(op.Name),
                            XedRender.format(action),
                            opvis.Code(),
                            opwidth(pattern.Mode, op),
                            op.IsReg ? FormatRegLit(op) : EmptyString,
                            op.SourceExpr
                            ));
                }

                return count;
            }

            string FormatRegLit(in PatternOp src)
            {
                var dst = EmptyString;
                if(src.RegLiteral(out var reg))
                    dst = reg.Format();
                return dst;
            }

            string FormatNonterm(in PatternOp src)
            {
                var dst = EmptyString;
                if(src.Nonterminal(out var nt))
                    dst = string.Format("{0}::{1}", nt, Tables.FindTablePath(nt));
                return dst;
            }

            static ushort bitwidth(OpWidthInfo src, MachineMode mode)
            {
                if(mode.Kind == ModeKind.Mode16)
                    return src.Width16;
                else if(mode.Kind == ModeKind.Mode32 || mode.Kind == ModeKind.Not64)
                    return src.Width32;
                else if(mode.Kind == ModeKind.Mode64)
                    return src.Width64;
                else
                    return src.Width64;
            }
        }
    }
}