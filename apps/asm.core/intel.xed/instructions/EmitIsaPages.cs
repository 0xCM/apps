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

    using K = XedRules.FieldKind;

    partial class XedPatterns
    {
        public Index<InstFieldInfo> CalcInstFields(Index<InstPattern> src)
        {
            var count = 0u;
            iter(src, p => count += p.Body.FieldCount);
            var dst = alloc<InstFieldInfo>(count);
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var body = ref pattern.Body;
                for(byte j=0; j<body.FieldCount; j++,k++)
                    seek(dst,k) = XedPatterns.fieldinfo(pattern, body[j], j);
            }
            return dst;
        }

        static uint IsaOutCount;

        public void EmitIsaPages(Index<InstPattern> src)
        {
            XedPaths.InstIsaRoot().Delete();
            var tables = XedRules.CalcTableSet(PllExec);
            iter(src.GroupBy(x => x.Isa.Kind), g => EmitIsaGroup(tables, g.Array()), PllExec);
        }

        static string FieldTitle = "Fields".PadRight(10).PadRight(80,Chars.Dash);

        static string OpsTitle = "Operands".PadRight(10).PadRight(80,Chars.Dash);

        void RenderFields(RuleTableSet tables, InstPattern src, ITextBuffer dst)
        {
            const string Pattern = "{0,-2} {1,-16} {2}";
            for(var j=0; j<src.Fields.Count; j++)
            {
                ref readonly var field = ref src.Fields[j];
                var fk = XedRender.format(field.FieldKind);
                if(field.IsLiteral)
                    dst.AppendLine(string.Format(Pattern, j, "Literal", field.Format()));
                else
                {
                    switch(field.FieldClass)
                    {
                        case DefFieldClass.Constraint:
                            dst.AppendLine(string.Format(Pattern, j, fk, field.AsConstraint()));
                        break;
                        case DefFieldClass.Nonterm:
                        {
                            var nt = field.AsNonterminal();
                            var path = FS.FileUri.Empty;
                            tables.FindSigInfo(nt.Name, out var sig);
                            path = sig.TableDef;
                            dst.AppendLine(string.Format(Pattern, j, "Nonterm",  string.Format("{0}::{1}", nt.Format(), path)));
                        }
                        break;
                        case DefFieldClass.Bitfield:
                            dst.AppendLine(string.Format(Pattern, j, fk, field.AsBitfield()));
                        break;
                        default:
                            dst.AppendLine(RP.Error);
                        break;
                    }
                }
            }
        }

        void EmitIsaGroup(RuleTableSet tables, Index<InstPattern> src)
        {
            var outpath = FS.FilePath.Empty;
            var classifier = EmptyString;
            var buffer = text.buffer();
            var opsLU = XedRules.CalcOpRecords(src).GroupBy(x => x.PatternId).Map(x => (x.Key, x.ToIndex())).ToConcurrentDictionary();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref src[i];

                if(pattern.Classifier != classifier)
                {
                    if(i!=0)
                    {
                        buffer.Emit(outpath);
                        inc(ref IsaOutCount);
                        if(IsaOutCount % 300 == 0)
                            Status(string.Format("Emitted {0} instructions", IsaOutCount));
                    }

                    classifier = pattern.Classifier;
                    outpath = XedPaths.InstIsaPath(pattern);
                    if(outpath.Exists)
                        Warn(string.Format("Overwriting {0}", outpath.ToUri()));

                    buffer.AppendLineFormat("{0,-18} {1,-12} {2,-12}", pattern.Classifier, pattern.Isa.Name, pattern.Category);
                    buffer.AppendLine(RP.PageBreak80);
                }
                else
                    buffer.AppendLine(RP.PageBreak80);

                buffer.AppendLine();
                buffer.AppendLineFormat("{0,-10}{1}", "Pattern", FormatIsaBody(pattern));
                if(pattern.InstForm.IsNonEmpty)
                    buffer.AppendLineFormat("{0,-10}{1}", "Form", pattern.InstForm);
                buffer.AppendLineFormat("{0,-10}{1}", "OpCode", pattern.OpCode);

                buffer.AppendLine(FieldTitle);
                RenderFields(tables,pattern,buffer);

                buffer.AppendLine();
                buffer.AppendLine(OpsTitle);

                if(opsLU.TryGetValue(pattern.PatternId, out var ops))
                {
                    for(var j=0; j<ops.Length; j++)
                        buffer.AppendLine(XedRender.semantic(ops[j]));
                }

                if(i==count - 1)
                    buffer.Emit(outpath);
            }
        }

        static string FormatIsaBody(InstPattern src)
        {
            ref readonly var body = ref src.Body;
            if(body.IsEmpty)
                return EmptyString;

            var k=0u;
            var j=0u;
            Span<InstDefField> buffer = stackalloc InstDefField[(int)body.FieldCount];
            Span<InstDefField> constraints = stackalloc InstDefField[(int)body.FieldCount];
            for(var i=0;i<body.FieldCount; i++)
            {
                ref readonly var field = ref body[i];
                switch(field.FieldKind)
                {
                    case K.MOD:
                        if(field.IsConstraint)
                            seek(constraints,j++) = field;
                        else if(field.IsBitfield)
                            seek(buffer,k++) = field;
                        else
                            seek(buffer,k++) = field;
                    break;
                    case K.EASZ:
                    case K.EOSZ:
                    case K.REP:
                    case K.LOCK:
                        if(field.IsConstraint)
                            seek(constraints,j++) = field;
                    break;
                    case K.MAP:
                    case K.VEX_PREFIX:
                    case K.VEXVALID:
                    case K.VL:
                    break;
                    default:
                        seek(buffer, k++) = field;
                    break;
                }
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

                    dst.Append(skip(constraints,i).Format());
                }
            }

            return dst.Emit();
        }
    }
}