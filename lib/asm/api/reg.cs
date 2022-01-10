//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using Operands;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static RegOp reg(NativeSizeCode width, RegClassCode @class, RegIndexCode r)
            => AsmRegs.reg(width, @class,r);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => AsmRegs.reg(src);

        [MethodImpl(Inline), Op]
        public static zmm v512(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static rCr rCr(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static rDb rDb(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static xCr xCr(RegIndexCode r)
            => r;
    }
}