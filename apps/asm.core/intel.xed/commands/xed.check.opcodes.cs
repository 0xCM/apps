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
        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var occols = new TableColumns(
                ("PatternId", 10),
                ("InstClass", 18),
                ("Index", 8),
                ("OpCode", 26),
                ("ModeLock", 8)
                //("Lock", 6)
                // ("Mod", 6),
                // ("RexW", 6),
                // ("Body", 1)
                );

            var opcols = new TableColumns(
                ("",10),
                ("Pos", 8),
                ("Name", 8),
                ("Kind", 6),
                ("Width", 6)
                );

            var counter = 0u;
            var patterns = Xed.Rules.CalcInstPatterns();
            var opcodes = XedOpCodes.poc(patterns);
            var patternLU = patterns.Select(x => ((ushort)x.PatternId,x)).ToDictionary();

            var dst = text.buffer();

            var ocdst = text.buffer();
            var ocbuffer = occols.Buffer();

            var opdst = text.buffer();
            var opbuffer = opcols.Buffer();

            var path = XedPaths.Targets() + FS.file("xed.inst.opdata", FS.Txt);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            ocbuffer.EmitHeader(writer);
            for(var i=0; i<opcodes.Count; i++)
            {
                ref readonly var poc = ref opcodes[i];
                ref readonly var layout = ref poc.Layout;
                ref readonly var expr = ref poc.Expr;

                var pattern = patternLU[poc.PatternId];

                ref readonly var ops = ref pattern.OpDetails;

                ocbuffer.Write(poc.PatternId);
                ocbuffer.Write(poc.InstClass);
                ocbuffer.Write(poc.Index);
                ocbuffer.Write(poc.OpCode);
                var mode =
                    poc.Mode.Kind == ModeKind.Mode64
                    ? "Mode64"
                    : (poc.Mode.Kind == ModeKind.Mode16
                     ? "Mode16"
                     : poc.Mode.Kind == ModeKind.Mode32
                     ? "Mode32"
                     : "Mode32x64"
                     );
                var @lock = poc.Lock.IsEmpty ? EmptyString : poc.Lock.Locked ? "Lock:1" : "Lock:0";
                var mlock = text.empty(@lock) ? mode : string.Format("{0} {{{1}}}",mode, @lock);
                ocbuffer.Write(mlock);

                writer.AppendLineFormat("{0,-10} | {1}", EmptyString, RP.PageBreak80);
                counter++;
                ocbuffer.EmitLine(writer);
                counter++;
                if(pattern.Layout.IsNonEmpty)
                    writer.AppendLineFormat("{0,-10} | {1}", EmptyString, pattern.Layout);
                counter++;
                writer.AppendLineFormat("{0,-10} | {1}", EmptyString, RP.PageBreak80);
                counter++;

                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    opbuffer.Write(EmptyString);
                    opbuffer.Write(op.Index);
                    opbuffer.Write(op.Name);
                    opbuffer.Write(op.Kind);
                    opbuffer.Write(op.GrpWidth.IsNonEmpty ? op.GrpWidth.Format() : op.BitWidth.ToString());
                    opbuffer.EmitLine(writer);
                    counter++;
                }
            }

            EmittedFile(emitting,counter);

            return true;
        }


        [CmdOp("xed/check/modrm")]
        Outcome CheckModRm(CmdArgs args)
        {
            var spec = ModRmVar.init();
            Write(spec.Format());

            spec.Mod(0b10);
            var a0 = spec.Evaluate();
            Require.equal(a0.Mod(), (uint2)0b10);
            Write(spec.Format());

            spec.Reg(0b101);
            var a1 = spec.Evaluate();
            Require.equal(a1.Reg(), (uint3)0b101);
            Write(spec.Format());

            spec.Rm(0b011);
            var a2 = spec.Evaluate();
            Require.equal(a2.Rm(), (uint3)0b011);
            Write(spec.Format());

            return true;
        }
    }
}