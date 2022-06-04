//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Asm.AsmRegTokens;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/check")]
        void RunAsmChecks()
        {
            vlut(w128);
            vlut(w256);
            CheckCcv();
        }

        [CmdOp("asm/emit")]
        void EmitAsmTokens()
        {
            //Sdm.EmitTokens();
            var src = Sdm.LoadOcDetails();
        }

        void GenHex8()
        {
            var dst = text.emitter();
            var indent = 4u;
            dst.IndentLineFormat(indent, "[SymSource(\"{0}\")]", "asm.opcodes");
            dst.IndentLineFormat(indent, "public enum {0} : byte", "Hex8Kind");
            dst.IndentLine(indent,"{");
            indent+=4;
            for(var i=0u; i<256; i++)
            {
                dst.IndentLineFormat(indent, "[Symbol(\"{0:X2}\")]", i);
                dst.IndentLineFormat(indent, "x{0:X2},", i);
                dst.AppendLine();
            }
            indent-=4;
            dst.IndentLine(indent,"}");
            Write(dst.Emit());

        }
        void vlut(W128 w)
        {
            // lut := <0,1,2,...,15> ; defines 16 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,79>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }

        void vlut(W256 w)
        {
            // lut := <0,1,2,...,31>  ; defines 32 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,95>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }

        void CheckCcv()
        {
            var r0 = Win64Ccv.reg(w64,0);
            Require.invariant(r0 == Gp64Reg.rcx);
            var r1 = Win64Ccv.reg(w64,1);
            Require.invariant(r1 == Gp64Reg.rdx);
            var r2 = Win64Ccv.reg(w64,2);
            Require.invariant(r2 == Gp64Reg.r8);
            var r3 = Win64Ccv.reg(w64,3);
            Require.invariant(r3 == Gp64Reg.r9);
            Write(string.Format("{0} | {1} | {2} | {3}", r0, r1, r2, r3));
        }
    }
}