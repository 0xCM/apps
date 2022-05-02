//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static Datasets;
    using static core;

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

            var storage = ByteBlock32.Empty;
            var ntcount = nonterms(ops, ref storage);
            if(ntcount != 0)
            {
                var rules = slice(storage.Storage<Nonterminal>(),0,ntcount);

            }
        }

        [CmdOp("xed/emit/layouts/ops")]
        Outcome EmitLyoutOps(CmdArgs args)
        {
            var cols = new TableColumns(
                ("PatternId", 10),
                ("InstClass", 18),
                ("Index", 8),
                ("OpCode", 26)
                );

            var counter = 0u;
            var opcodes = CalcPatternOpCodes();
            var patterns = CalcPatterns().Select(x => ((ushort)x.PatternId,x)).ToDictionary();

            var dst = cols.Buffer();
            var path = XedPaths.Target("xed.inst.layouts.ops", FS.Txt);
            var emitting = EmittingFile(path);
            using var writer = path.Emitter();
            dst.EmitHeader(writer);
            for(var i=0; i<opcodes.Count; i++)
            {
                ref readonly var poc = ref opcodes[i];

                var pattern = patterns[poc.PatternId];

                ref readonly var ops = ref pattern.OpDetails;
                dst.Write(poc.PatternId);
                dst.Write(poc.InstClass.Classifier);
                dst.Write(poc.Index);
                dst.Write(poc.OpCode);

                writer.AppendLineFormat("{0,-10} | {1}", EmptyString, RP.PageBreak120);
                counter++;
                dst.EmitLine(writer);
                counter++;

                writer.AppendLineFormat("{0,-10} | {1}", EmptyString, LayoutCalcs.layout(pattern));

                counter++;
                writer.AppendLineFormat("{0,-10} | {1}", EmptyString, RP.PageBreak120);
                counter++;


                Render(pattern.OpDetails,writer);
            }

            EmittedFile(emitting,counter);

            return true;
        }
    }
}