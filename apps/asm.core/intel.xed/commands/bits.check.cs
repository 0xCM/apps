//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static Char5;

    partial class XedCmdProvider
    {
        void GenBitfield(ITextEmitter log)
        {
            var modrm = BitfieldPatterns.infer(ModRm.BitPattern);
            log.WriteLine(modrm.Descriptor);

            var rex = BitfieldPatterns.infer(RexPrefix.BitPattern);
            log.WriteLine(rex.Descriptor);

            var vexC4 = BitfieldPatterns.infer(VexPrefixC4.BitPattern);
            log.WriteLine(vexC4.Descriptor);

            var vexC5 = BitfieldPatterns.infer(VexPrefixC5.BitPattern);
            log.WriteLine(vexC5.Descriptor);

            var sib = BitfieldPatterns.infer(Sib.BitPattern);
            log.WriteLine(sib.Descriptor);

            byte data = 0b10_110_011;
            log.WriteLine(BitfieldPatterns.bitstring(sib, data));
        }

        void CheckBitReplication(ITextEmitter log)
        {
            const byte PW = 4;

            const byte P0 = 0b0111;

            const byte E0 = P0 | P0 << PW;

            const ushort P1 = 0b0111;

            const ushort E1 = (ushort)E0 | (ushort)E0 << PW*2;

            const uint P2 = 0b0111;

            const uint E2 = (uint)E1 | (uint)E1 << PW*4;

            const ulong P3 = 0b0111;

            const ulong E3 = (ulong)E2 | (ulong)E2 << PW*8;

            var A0 = gbits.replicate(P0, 0, 3, 8/PW);
            var R0 = Require.equal(E0,A0);
            log.WriteLine(R0.FormatBits());

            var A1 = gbits.replicate(P1, 0, 3, 16/PW);
            var R1 = Require.equal(E1,A1);
            log.WriteLine(R1.FormatBits());

            var A2 = gbits.replicate(P2, 0, 3, 32/PW);
            var R2 = Require.equal(E2,A2);
            log.WriteLine(R2.FormatBits());

            var A3 = gbits.replicate(P3, 0, 3, 64/PW);
            var R3 = Require.equal(E3,A3);
            log.WriteLine(R3.FormatBits());

        }

        void CheckBitNumbers(ITextEmitter log)
        {
            BitNumber.validate(n3, (byte)0b0000_0111, log);
            BitNumber.validate(n6, (byte)0b0011_1000, log);

            BitNumber.validate(n3, (ushort)0b0000_0111, log);
            BitNumber.validate(n6, (ushort)0b0011_1000, log);

            BitNumber.validate(n3, (uint)0b0000_0111, log);
            BitNumber.validate(n6, (uint)0b0011_1000, log);
        }

        void CheckSegVars(ITextEmitter log)
        {
            var a = Code.A;
            var b = Code.B;
            var c = Code.C;
            var _ = Code._;
            var d = Code.D;

            var v0 = new SegVar(a, b, c, _, d);
            var v1 = new SegVar(Code.W, Code.R, Code.X, Code.B);
            log.WriteLine(v0.Format());
            log.WriteLine(v1.Format());

            var input = "ss_ii_bbbb";
            var v2 = SegVar.parse(input);
            var output = v2.Format();
            var result = Require.equal(input,output);
            log.WriteLine(result);
        }


        [CmdOp("bits/check")]
        Outcome CheckBits(CmdArgs args)
        {
            CheckRunner.run(true, (nameof(CheckBitNumbers), CheckBitNumbers),
            (nameof(CheckBitReplication), CheckBitReplication),
            (nameof(GenBitfield), GenBitfield),
            (nameof(CheckSegVars), GenBitfield)
            );

            return true;
        }
    }
}