//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static Datasets;
    using static core;

    partial class XTend
    {
        public static void AppendLines<T>(this ITextEmitter dst, ReadOnlySpan<T> src)
        {
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i));
        }

        public static void AppendLines<T>(this ITextEmitter dst, Span<T> src)
        {
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i));
        }

    }
    partial class XedCmdProvider
    {
        TableColumns OperandCols = new TableColumns(
            ("",10),
            ("Pos", 8),
            ("Name", 8),
            ("Kind", 10),
            ("Width", 10),
            ("Count", 4),
            ("Type", 8),
            ("Code", 10),
            ("Nonterm",10),
            ("Expr", 1)
            );

        static uint nonterms<T>(Index<InstOpDetail> src, ref T dst)
            where T : unmanaged, IStorageBlock<T>
        {
            var j = 0u;
            var target = dst.Bytes.Recover<RuleName>();
            for(var i=0; i<src.Length; i++)
            {
                if(src[i].IsNonterm)
                    seek(target,j++) = src[i].NonTerm.Name;
            }
            return j;
        }

        void Render(Index<InstOpDetail> ops, ITextEmitter dst)
        {
            var buffer = OperandCols.Buffer();
            var iv = BitVector64.Zero;
            var kv = BitVector64.Zero;
            for(var j=0; j<ops.Count; j++)
            {
                ref readonly var op = ref ops[j];
                buffer.Write(EmptyString);
                buffer.Write(op.Index);
                buffer.Write(XedRender.format(op.Name));
                buffer.Write(XedRender.format(op.Kind));
                buffer.Write(op.GrpWidth.IsNonEmpty ? op.GrpWidth.Format() : op.BitWidth.ToString());
                buffer.Write(op.ElementCount);
                buffer.Write(op.ElementType);
                if(op.WidthCode != 0)
                    buffer.Write(XedRender.format(op.WidthCode));
                else
                    buffer.Write(EmptyString);

                if(op.IsNonterm)
                    buffer.Write(op.NonTerm);
                else
                    buffer.Write(EmptyString);

                buffer.Write(op.SourceExpr);
                buffer.EmitLine(dst);
            }
        }

        [CmdOp("xed/emit/opvecs")]
        Outcome EmitOpVectors(CmdArgs args)
        {
            var dst = text.emitter();
            Span<string> buffer = alloc<string>(256);
            var patterns = CalcPatterns();
            var k=z8;
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var ops = ref pattern.Ops;
                dst.AppendLineFormat(InstRender.LabelPattern, "Pattern", string.Format("{0,-10} | {1,-18} | {2,-26}", pattern.PatternId, pattern.InstClass.Classifier, pattern.OpCode));
                dst.AppendLineFormat(InstRender.LabelPattern, "Layout", LayoutCalcs.layout(pattern));
                k = InstRender.fields(pattern,buffer);
                for(var j=0; j<k; j++)
                    dst.AppendLine(skip(buffer,j));


                dst.AppendLine(InstRender.OpsHeader);
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    var desc = OpDescriptor.calc(pattern.Mode, op);
                    dst.AppendLine(desc);
                }
                // k = InstRender.operands(pattern,buffer);
                // for(var j=0; j<k; j++)
                //     dst.AppendLine(skip(buffer,j));

                dst.AppendLine();

                dst.AppendLine(RP.PageBreak180);

            }


            FileEmit(dst.Emit(), patterns.Count, XedPaths.Target("xed.inst.layouts.ops", FS.Txt));

            return true;
        }
    }
}