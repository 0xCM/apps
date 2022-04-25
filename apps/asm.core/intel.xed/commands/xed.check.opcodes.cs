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

        [CmdOp("bits/check/numbers")]
        Outcome CheckBitNumbers(CmdArgs args)
        {
            CheckBitNumbers(n3, (byte)0b0000_0111);
            CheckBitNumbers(n6, (byte)0b0011_1000);

            CheckBitNumbers(n3, (ushort)0b0000_0111);
            CheckBitNumbers(n6, (ushort)0b0011_1000);

            CheckBitNumbers(n3, (uint)0b0000_0111);
            CheckBitNumbers(n6, (uint)0b0011_1000);

            return true;
        }

        static BitString bitstring<N,T>(N n, T src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(size<T>() <=8)
                return u8(src).ToBitString((byte)n.NatValue);
            else if(size<T>() <=16)
                return u16(src).ToBitString((byte)n.NatValue);
            else if(size<T>() <=32)
                return u32(src).ToBitString((byte)n.NatValue);
            else
                return u64(src).ToBitString((byte)n.NatValue);
        }

        void CheckBitNumbers<N,T>(N n, T value)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var bn = BitNumber.generic(n,value);
            var width = Require.equal((byte)n.NatValue, bn.Width);
            var bs = bitstring(n,value);
            var scalar = bn.Value;
            Require.invariant(gmath.eq(scalar,value));
            var bits = Require.equal(bs.Format(), bn.Format());
            Write(string.Format("{0:D2} | {1:X4} | {2}", width, scalar, bits));
        }
    }
}