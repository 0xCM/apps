//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static math;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static RegOp reg(NativeSizeCode width, RegClassCode @class, RegIndexCode r)
            => AsmRegs.reg(width,@class,r);

        // [MethodImpl(Inline), Op]
        // public static RegOp reg(RegKind kind)
        //     => new RegOp((ushort)kind);

        // [MethodImpl(Inline)]
        // public static RegOp<T> reg<T>(T src)
        //     where T : unmanaged, IRegOp
        //         => new RegOp<T>(src);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => AsmRegs.reg(src);
    }
}