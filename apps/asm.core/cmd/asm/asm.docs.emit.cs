//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Asm.AsmPrefixCodes;

    partial class AsmCoreCmd
    {
        public void EmitAsmDocs()
            => AsmDocs.Emit();

        [CmdOp("asm/docs/emit")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            EmitAsmDocs();
            return true;
        }


        [CmdOp("asm/check/vex")]
        Outcome Vex(CmdArgs args)
        {
            var segments = VexPrefixC4.segments();

            var vp0 = VexPrefixC4.define(byte.MaxValue, byte.MaxValue);
            Write(vp0.FormatSemantic());
            segments.Fill(vp0);
            Write(segments.ToBitstring());

            var vp1 = VexPrefixC4.init(VexRXB.L0_V0F38, VexM.x0F3A, bit.On, 0b1111, VexLengthCode.L1, VexOpCodeExtension.F3);
            Write(vp1.FormatSemantic());
            segments.Fill(vp1);
            Write(segments.ToBitstring());

            var vp2 = VexPrefixC4.define(0xe3, 0x69);
            Write(vp2.FormatSemantic());
            segments.Fill(vp2);
            Write(segments.ToBitstring());

            return true;
        }

        public void vlut(W128 w)
        {
            // lut := <0,1,2,...,15> ; defines 16 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,79>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }

        public void vlut(W256 w)
        {
            // lut := <0,1,2,...,31>  ; defines 32 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,95>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }
    }
}