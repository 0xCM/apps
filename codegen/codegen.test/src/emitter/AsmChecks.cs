//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    //using Asm.Operands;
    using static core;
    using static Asm.AsmEmitter;
    using static Asm.AsmRegOps;

    public class AsmChecks : Checker<AsmChecks>
    {
        public void CheckAsmBytes(bit x)
        {
            var hex = AsmHexCode.Empty;
            var dst = AsmHexWriter.create(hex.Bytes);
            var expr = EmptyString;
            hex.Size = and(al, bl, dst);
            expr = string.Format("{0} {1}, {2}", "and", al, bl);
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(cl, bl, dst);
            expr = string.Format("{0} {1}, {2}", "and", cl, bl);
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(dl, bl, dst);
            expr = string.Format("{0} {1}, {2}", "and", dl, bl);
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(ah, bl, dst);
            expr = string.Format("{0} {1}, {2}", "and", ah, bl);
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(ch, bl, dst);
            expr = string.Format("{0} {1}, {2}", "and", ch, bl);
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(dh, bl, dst);
            expr = string.Format("{0} {1}, {2}", "and", dh, bl);
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(bh, bl, dst);
            expr = string.Format("{0} {1}, {2}", "and", bh, bl);
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();


            Write(string.Format("{0} | {1} | {2} | {3}", ah.Index, ch.Index, dh.Index, bh.Index));
        }

        /*
        AND16ri8 | 4        | 66 83 e0 73           | and ax, 0x73      | Reg:ax, Imm:115
        AND16ri8 | 4        | 66 83 e1 73           | and cx, 0x73      | Reg:cx, Imm:115
        AND16ri8 | 4        | 66 83 e2 73           | and dx, 0x73      | Reg:dx, Imm:115
        AND16ri8 | 4        | 66 83 e3 73           | and bx, 0x73      | Reg:bx, Imm:115
        AND16ri8 | 4        | 66 83 e4 73           | and sp, 0x73      | Reg:sp, Imm:115
        AND16ri8 | 4        | 66 83 e5 73           | and bp, 0x73      | Reg:bp, Imm:115
        AND16ri8 | 4        | 66 83 e6 73           | and si, 0x73      | Reg:si, Imm:115
        AND16ri8 | 4        | 66 83 e7 73           | and di, 0x73      | Reg:di, Imm:115
        AND16ri8 | 5        | 66 41 83 e0 73        | and r8w, 0x73     | Reg:r8w, Imm:115
        AND16ri8 | 5        | 66 41 83 e1 73        | and r9w, 0x73     | Reg:r9w, Imm:115
        AND16ri8 | 5        | 66 41 83 e2 73        | and r10w, 0x73    | Reg:r10w, Imm:115
        AND16ri8 | 5        | 66 41 83 e3 73        | and r11w, 0x73    | Reg:r11w, Imm:115
        AND16ri8 | 5        | 66 41 83 e4 73        | and r12w, 0x73    | Reg:r12w, Imm:115
        AND16ri8 | 5        | 66 41 83 e5 73        | and r13w, 0x73    | Reg:r13w, Imm:115
        AND16ri8 | 5        | 66 41 83 e6 73        | and r14w, 0x73    | Reg:r14w, Imm:115
        AND16ri8 | 5        | 66 41 83 e7 73        | and r15w, 0x73    | Reg:r15w, Imm:115
        */

        public void CheckAnd()
        {

            // AND16ri8 | 8ah | 4 | 66 83 e0 73 | and ax, 0x73 | Reg:ax, Imm:115
            var a0 = and_r16_imm8(AsmRegOps.ax, 0x73);

            Write(string.Format("{0} | {1} | {2}", a0.Id, a0.EncodingSize, a0.Format()));
            //Write(string.Format("{0} | ", a0.Format()));

        }
    }
}