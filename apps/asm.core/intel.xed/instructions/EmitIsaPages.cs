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

    using K = XedRules.FieldKind;

    partial class XedPatterns
    {
        static uint IsaOutCount;

        public void EmitIsaPages(Index<InstPattern> src)
        {
            XedPaths.InstIsaRoot().Delete();
            iter(src.GroupBy(x => x.Isa.Kind), g => EmitIsaGroup(g.Array()), PllExec);
        }

        void EmitIsaGroup(Index<InstPattern> src)
        {
            var outpath = FS.FilePath.Empty;
            var classifier = EmptyString;
            var buffer = text.buffer();
            var opsLU = XedRules.CalcOpRecords(src).GroupBy(x => x.PatternId).Map(x => (x.Key,x.ToArray())).ToConcurrentDictionary();
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
                        if(IsaOutCount % 100 == 0)
                            Status(string.Format("Emitted {0} instructions", IsaOutCount));
                    }

                    classifier = pattern.Classifier;
                    outpath = XedPaths.InstIsaPath(pattern);

                    buffer.AppendLineFormat("{0,-18} {1,-12} {2,-12}", pattern.Classifier, pattern.Isa.Name, pattern.Category);
                    buffer.AppendLine(RP.PageBreak80);
                }
                else
                    buffer.AppendLine(RP.PageBreak80);

                buffer.AppendLineFormat("{0} {1}", XedRender.semantic(pattern.OpCode), pattern.InstForm);
                buffer.AppendLine(FormatIsaBody(pattern));
                var ops = sys.empty<PatternOpInfo>();
                if(opsLU.TryGetValue(pattern.PatternId, out ops))
                {
                    for(var j=0; j<ops.Length; j++)
                        buffer.AppendLine(XedRender.semantic(skip(ops,j)));
                }

                if(i==count - 1)
                    buffer.Emit(outpath);
            }
        }

        static string format(in InstDefField src)
        {
            var dst = EmptyString;
            switch(src.FieldKind)
            {
                case K.VL:
                {
                    dst = "v" + XedRender.format(src.AsAssignment().Value.ToVexLength());
                }
                break;
                default:
                    dst = src.Format();
                break;
            }


            return dst;
        }

        static string FormatIsaBody(InstPattern src)
        {
            ref readonly var body = ref src.Body;
            if(body.IsEmpty)
                return EmptyString;

            var k=0u;
            var j=0u;
            Span<InstDefField> buffer = stackalloc InstDefField[(int)body.FieldCount];
            Span<InstDefField> constraints = stackalloc InstDefField[3];
            for(var i=0;i<body.FieldCount; i++)
            {
                ref readonly var field = ref body[i];
                    switch(field.FieldKind)
                    {
                        case K.MOD:
                            if(field.FieldClass == DefFieldClass.Constraint)
                                seek(constraints,j++) = field;
                            else if(field.FieldClass == DefFieldClass.Bitfield)
                                seek(buffer,k++) = field;
                            else
                                seek(buffer,k++) = field;
                        break;
                        case K.MAP:
                        case K.VEX_PREFIX:
                        case K.VEXVALID:
                        case K.VL:
                        break;
                        default:
                            seek(buffer,k++) = field;
                        break;
                    }
            }

            var dst = text.buffer();
            var cx = EmptyString;
            for(var i=0; i<k; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);

                dst.Append(format(skip(buffer,i)));
            }

            if(j != 0)
            {
                dst.Append(" where ");

                for(var i=0; i<j; i++)
                {
                    if(i!=0)
                        dst.Append(" && ");

                    dst.Append(format(skip(constraints,i)));
                }
            }


            return dst.Emit();
        }

    }
}