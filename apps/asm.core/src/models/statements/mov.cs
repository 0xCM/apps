//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static AsmOperands;

    using N = AsmNames;

    partial struct AsmStatements
    {
        /// <summary>
        /// (88 /r | REX + 88 /r)  | mov r8,r8
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmStatement mov(r8 a, r8 b)
            => string.Format(RP2, N.mov, a, b);

        /// <summary>
        /// (88 /r | REX + 88 /r) mov m8,r8
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmStatement mov(m8 a, r8 b)
            => string.Format(RP2, N.mov, a, b);

        /// <summary>
        /// 89 /r             | MOV r/m16,r16
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmStatement mov(r16 a, r16 b)
            => string.Format(RP2, N.mov, a, b);

        /// <summary>
        /// 89 /r             | MOV r/m16,r16
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Op]
        public static AsmStatement mov(m16 a, r16 b)
            => string.Format(RP2, N.mov, a, b);
    }
}