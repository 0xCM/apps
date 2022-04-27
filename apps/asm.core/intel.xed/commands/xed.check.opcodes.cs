//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;
    using static Datasets;

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

        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var occols = new TableColumns(
                ("PatternId", 10),
                ("InstClass", 18),
                ("Index", 8),
                ("OpCode", 26),
                ("Id", 8)
                );

            var counter = 0u;
            var patterns = Xed.Rules.CalcInstPatterns();
            var opcodes = XedOpCodes.poc(patterns);
            var patternLU = patterns.Select(x => ((ushort)x.PatternId,x)).ToDictionary();

            var dst = occols.Buffer();

            var path = XedPaths.Targets() + FS.file("xed.inst.opdata", FS.Txt);
            var emitting = EmittingFile(path);
            using var writer = path.Emitter();
            dst.EmitHeader(writer);
            for(var i=0; i<opcodes.Count; i++)
            {
                ref readonly var poc = ref opcodes[i];
                ref readonly var layout = ref poc.Layout;
                ref readonly var expr = ref poc.Expr;

                var pattern = patternLU[poc.PatternId];

                ref readonly var ops = ref pattern.OpDetails;

                dst.Write(poc.PatternId);
                dst.Write(poc.InstClass);
                dst.Write(poc.Index);
                dst.Write(poc.OpCode);
                dst.Write(poc.OcInstClass());

                writer.AppendLineFormat("{0,-10} | {1}", EmptyString, RP.PageBreak120);
                counter++;
                dst.EmitLine(writer);
                counter++;
                if(pattern.Layout.IsNonEmpty)
                    writer.AppendLineFormat("{0,-10} | {1}", EmptyString, pattern.Layout);
                counter++;
                writer.AppendLineFormat("{0,-10} | {1}", EmptyString, RP.PageBreak120);
                counter++;


                Render(ops,writer);
            }

            EmittedFile(emitting,counter);

            return true;
        }
    }
}