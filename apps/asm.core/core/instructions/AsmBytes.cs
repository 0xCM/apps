//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static Hex8Kind;

    [ApiHost]
    public class AsmBytes
    {
        [MethodImpl(Inline), Op]
        public static BinaryCode code(in CodeBlock src, uint offset, byte size)
            => core.slice(src.View, offset, size).ToArray();

        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// (AND AL, imm8)[24 ib]
        /// </summary>
        /// <param name="r"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public static byte and(al r, imm8 imm8, AsmHexWriter dst)
        {
            return dst.Write(x24,imm8);
        }

        /// <summary>
        /// 20 /r | AND r/m8, r8 | 0x20 MOD[0b11] REG[rrr] RM[nnn]
        /// </summary>
        /// <param name="r0">REG0=GPR8_B():rw</param>
        /// <param name="r1">REG1=GPR8_R():r</param>
        public static byte and(r8 r0, r8 r1, AsmHexWriter dst)
        {
            var modrm = ModRm.init();
            modrm.Mod(0b11);
            modrm.Reg(r1);
            modrm.Rm(r0);
            return dst.Write(x20, modrm);
        }

        [MethodImpl(Inline), Op]
        public static byte jo(Hex8 cb, AsmHexWriter dst)
            => dst.Write(x70, cb);

        [MethodImpl(Inline), Op]
        public static byte jo(Hex32 cd, AsmHexWriter dst)
            => dst.Write(x70, x86, cd);


        [MethodImpl(Inline), Op]
        public static byte encode(Hex8 a0, imm8 a1, AsmHexWriter dst)
            => dst.Write(a0,a1);

        [MethodImpl(Inline), Op]
        public static byte encode(RexPrefix a0, Hex8 a1, imm64 a2, Span<byte> buffer)
        {
            var dst = writer(buffer);
            return dst.Write(a0,a1,a2);
        }

        [MethodImpl(Inline), Op]
        public static byte encode(Rip a0, Jcc8 a1, AsmHexWriter dst)
            => dst.Write(a1.JccCode, AsmRel8.target(a0, a1.Disp));

        [MethodImpl(Inline), Op]
        static AsmHexWriter writer(Span<byte> buffer)
            => new AsmHexWriter(buffer);
    }
}