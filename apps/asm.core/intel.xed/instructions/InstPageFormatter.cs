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
            public static InstPageFormatter create(RuleTableSet tables)
                => new InstPageFormatter(tables);

            public static Index<InstIsaFormat> FormatGroups(RuleTableSet tables, Index<InstPattern> src)
            {
                var buffer = bag<InstIsaFormat>();
                iter(src.GroupBy(x => x.Isa.Kind), g => buffer.Add(FormatGroup(tables, g.Key, g.Array())), AppData.PllExec());
                return buffer.Array().Sort();
            }

            static InstIsaFormat FormatGroup(RuleTableSet tables, InstIsa isa, Index<InstPattern> src)
                => create(tables).FormatGroup(isa,src);

            const byte SectionWidth = 140;

            const byte InstWidth = 180;

            const string InstSep = RP.PageBreak160 + RP.PageBreak20;

            static string FieldTitle = "Fields".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            static string OpsTitle = "Operands".PadRight(18).PadRight(SectionWidth, Chars.Dash);

            const string LabelPattern = "{0,-18}{1}";

            readonly RuleTableSet Tables;

            readonly ITextBuffer Dst;

            readonly XedLookups Lookups;

            readonly Index<string> Buffer;

            uint Counter;

            [MethodImpl(Inline)]
            public InstPageFormatter(RuleTableSet tables)
            {
                Tables = tables;
                Dst = text.buffer();
                Lookups = XedLookups.Data;
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
                AppendLine(FormatBody(pattern));
                AppendLineFormat(LabelPattern, nameof(pattern.Mode), XedRender.format(pattern.Mode));
                AppendLineFormat(LabelPattern, nameof(pattern.OpCode), string.Format("{0,-8} {1}", pattern.OpCode.Kind, AsmOcValue.format(pattern.OpCode.Value)));

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
                for(var i=0; i<src.Count; i++)
                    Render(src[i]);
                return new (isa, src, Emit());
            }

            public string FormatInstHeader(InstPattern src)
                => string.Format("{0,-18}{1,-18}{2}", src.InstClass, src.Isa, src.InstForm);

            public string FormatWidth(InstPattern pattern, in PatternOp src)
            {
                const string RenderPattern = "{0,-6} {1,-12} {2,-8} {3,-2}";
                if(XedPatterns.reglit(src, out Register reg))
                    return string.Format(RenderPattern, "reg", XedPatterns.bitwidth(reg).ToString(), EmptyString, EmptyString);;

                var dst = EmptyString;
                src.OpWidth(out var w);
                var wi = w.Code != 0 ? Lookups.WidthInfo(w.Code) : OpWidthInfo.Empty;
                var bw = EmptyString;
                bw = bitwidth(wi,pattern.Mode).ToString();
                if(wi.IsNonEmpty)
                    dst = string.Format(RenderPattern, XedRender.format(wi.Code), bw, wi.Seg.Format(), wi.Seg.CellCount);

                if(w.DefinesGprWidth)
                    dst = string.Format(RenderPattern, "ntv", w, EmptyString, EmptyString);

                if(empty(dst))
                    dst = string.Format(RenderPattern, EmptyString, EmptyString, EmptyString, EmptyString);

                return dst;
            }

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
                        switch(field.FieldClass)
                        {
                            case DefFieldClass.FieldExpr:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.AsFieldExpr());
                                break;
                            case DefFieldClass.Nonterm:
                            {
                                var nt = field.AsNonterminal();
                                var path = Tables.FindTablePath(nt.Name);
                                seek(dst,j) = string.Format(Pattern, j, "Nonterm",  string.Format("{0}::{1}", nt.Format(), path));
                            }
                            break;
                            case DefFieldClass.Bitfield:
                                seek(dst,j) = string.Format(Pattern, j, fk, field.AsBitfield());
                            break;
                            default:
                                Errors.Throw(string.Format("Unhandled case: {0}", field.FieldClass));
                            break;
                        }
                    }
                }
                return count;
            }

            string FormatBody(InstPattern src)
            {
                ref readonly var body = ref src.Body;
                if(body.IsEmpty)
                    return EmptyString;

                var k=0u;
                var j=0u;
                Span<InstDefField> buffer = stackalloc InstDefField[(int)body.FieldCount];
                Span<InstDefField> expressions = stackalloc InstDefField[(int)body.FieldCount];
                for(var i=0;i<body.FieldCount; i++)
                {
                    ref readonly var field = ref body[i];
                    if(field.IsFieldExpr)
                        seek(expressions,j++) = field;
                    else
                        seek(buffer,k++) = field;
                }

                var dst = text.buffer();
                var cx = EmptyString;
                for(var i=0; i<k; i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Space);

                    dst.Append(skip(buffer,i).Format());
                }

                if(j != 0)
                {
                    dst.Append(" where ");

                    for(var i=0; i<j; i++)
                    {
                        if(i!=0)
                            dst.Append(" && ");

                        dst.Append(skip(expressions,i).Format());
                    }
                }

                return string.Format("{0,-18}{1}", "Pattern", dst.Emit());
            }

            byte RenderOps(InstPattern pattern, Span<string> dst)
            {
                ref readonly var ops = ref pattern.Ops;
                var count = (byte)ops.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var op = ref ops[j];
                    op.Action(out var action);
                    op.Visibility(out var opvis);
                    seek(dst,j) = (string.Format("{0,-2} {1,-14} {2,-4} {3,-4} {4} {5,-88} [{6}]",
                        op.Index,
                        XedRender.format(op.Name),
                        XedRender.format(action),
                        opvis.Code(),
                        FormatWidth(pattern,op),
                        op.IsReg ? FormatRegOp(op) : EmptyString,
                        op.SourceExpr
                        ));
                }

                return count;
            }

            string FormatRegOp(in PatternOp src)
            {
                var dst = EmptyString;
                if(src.RegLiteral(out var reg))
                    dst = reg.Format();
                else
                {
                    if(src.Nonterminal(out var nt))
                        dst = string.Format("{0}()::{1}", nt.Name, Tables.FindTablePath(nt.Name));
                }
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