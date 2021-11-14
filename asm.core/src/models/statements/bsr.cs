//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmOperands;

    partial struct AsmStatements
    {
        [Op]
        public static AsmStatement bsr(r16 a, r16 b)
            => string.Format(RP2, nameof(bsr), a,b);

        [Op]
        public static AsmStatement bsr(r16 a, m16 b)
            => string.Format(RP2, nameof(bsr), a,b);

        [Op]
        public static AsmStatement bsr(r32 a, r32 b)
            => string.Format(RP2, nameof(bsr), a,b);

        [Op]
        public static AsmStatement bsr(r32 a, m32 b)
            => string.Format(RP2, nameof(bsr), a,b);

        [Op]
        public static AsmStatement bsr(r64 a, r64 b)
            => string.Format(RP2, nameof(bsr), a,b);

        [Op]
        public static AsmStatement bsr(r64 a, m64 b)
            => string.Format(RP2, nameof(bsr), a,b);
    }
}