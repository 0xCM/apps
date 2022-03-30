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

    partial class XedPatterns
    {
        static uint IsaOutCount;

        public static string FormatIsaHeader(InstPattern pattern)
            => string.Format("{0,-18} {1,-12} {2,-12} {3}", pattern.Classifier, pattern.Isa.Name, pattern.Category, pattern.InstForm);

        public static byte RenderOps(RuleTableSet tables, InstPattern pattern, Span<string> dst)
        {
            ref readonly var ops = ref pattern.Ops;
            var count = (byte)ops.Count;
            for(var j=0; j<count; j++)
            {
                var op = ops[j].Describe();
                var width = XedLookups.Data.WidthInfo(op.OpWidth.Code);
                var ntpath = op.IsNonTerminal ? tables.FindTablePath(op.NonTerminal.Name) : FS.FileUri.Empty;
                seek(dst,j) = (string.Format("{0,-2} {1,-5} {2,-5} {3,-3} {4,-3} {5}",
                    op.Index,
                    XedRender.format(op.Name),
                    width.IsEmpty ? op.OpWidth.Bits.ToString() : string.Format("{0,-8} w{1,-8} {2,-2}", XedRender.format(op.OpWidth.Code), width.Seg.Format(), width.Seg.CellCount),
                    op.Visibility.Code(),
                    XedRender.format(op.Action),
                    IsRegOp(op.Kind) ? (op.RegLit != 0 ? XedRender.format(op.RegLit) : string.Format("{0}()::{1}", op.NonTerminal.Name, ntpath)) : EmptyString
                    ));
            }

            return count;
        }

        public static byte RenderFields(RuleTableSet tables, InstPattern src, Span<string> dst)
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
                            var path = tables.FindTablePath(nt.Name);
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

        public static string FormatIsaBody(InstPattern src)
        {
            ref readonly var body = ref src.Body;
            if(body.IsEmpty)
                return EmptyString;

            var k=0u;
            var j=0u;
            Span<InstDefPart> buffer = stackalloc InstDefPart[(int)body.FieldCount];
            Span<InstDefPart> expressions = stackalloc InstDefPart[(int)body.FieldCount];
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

            return string.Format("{0,-18} {1}", "Pattern", dst.Emit());
        }

        public void EmitIsaPages(RuleTableSet tables, Index<InstPattern> patterns)
        {
            XedPaths.InstIsaRoot().Delete();
            iter(patterns.GroupBy(x => x.Isa.Kind), g => EmitIsaGroup(tables, g.Array()), PllExec);
        }

        public static string FieldTitle = "Fields".PadRight(18).PadRight(120,Chars.Dash);

        public static string OpsTitle = "Operands".PadRight(18).PadRight(120,Chars.Dash);

        static bool IsRegOp(OpKind src)
        {
            var result = false;
            switch(src)
            {
                case OpKind.Reg:
                case OpKind.Seg:
                case OpKind.Base:
                case OpKind.Index:
                    result = true;
                break;
            }
            return result;
        }

        void EmitIsaGroup(RuleTableSet tables, Index<InstPattern> src)
        {
            var outpath = FS.FilePath.Empty;
            var classifier = EmptyString;
            var dst = text.buffer();
            var count = src.Count;
            Span<string> rbuffer = alloc<string>(42);
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref src[i];

                if(pattern.Classifier != classifier)
                {
                    if(i!=0)
                    {
                        dst.Emit(outpath);
                        inc(ref IsaOutCount);
                        if(IsaOutCount % 300 == 0)
                            Status(string.Format("Emitted {0} instructions", IsaOutCount));
                    }

                    classifier = pattern.Classifier;
                    outpath = XedPaths.InstIsaPath(pattern);
                    if(outpath.Exists)
                        Warn(string.Format("Overwriting {0}", outpath.ToUri()));

                }

                if(i!=0)
                    dst.AppendLine(RP.PageBreak120);

                dst.AppendLine(FormatIsaHeader(pattern));
                dst.AppendLine(FormatIsaBody(pattern));
                dst.AppendLineFormat("{0,-18} {1}", "OpCode", pattern.OpCode);

                dst.AppendLine(XedPatterns.FieldTitle);
                var fcount = XedPatterns.RenderFields(tables, pattern, rbuffer);
                for(var j=0; j<fcount;j++)
                    dst.AppendLine(skip(rbuffer,j));

                dst.AppendLine(XedPatterns.OpsTitle);
                var opscount = XedPatterns.RenderOps(tables, pattern, rbuffer);
                for(var j=0; j<opscount;j++)
                    dst.AppendLine(skip(rbuffer,j));

                dst.AppendLine();

                if(i==count - 1)
                    dst.Emit(outpath);
            }
        }
    }
}