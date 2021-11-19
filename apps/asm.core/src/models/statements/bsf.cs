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
        [Op]
        public static AsmStatement bsf(r16 a, r16 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmStatement bsf(r16 a, m16 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmStatement bsf(r32 a, r32 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmStatement bsf(r32 a, m32 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmStatement bsf(r64 a, r64 b)
            => string.Format(RP2, N.bsf, a,b);

        [Op]
        public static AsmStatement bsf(r64 a, m64 b)
            => string.Format(RP2, N.bsf, a,b);
    }
}