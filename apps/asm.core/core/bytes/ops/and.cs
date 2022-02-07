//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    using static Hex8Kind;

    partial class AsmBytes
    {
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
    }
}