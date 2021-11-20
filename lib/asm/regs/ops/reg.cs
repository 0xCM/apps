//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
     using System;
     using System.Runtime.CompilerServices;

    using static Root;
    using static math;
    using static core;

    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static RegOp reg(NativeSizeCode width, RegClassCode @class, RegIndexCode r)
            => new RegOp(or((byte)width, sll((ushort)@class, 5), sll((ushort)r, 10)));

        [MethodImpl(Inline), Op]
        public static RegOp reg(RegKind kind)
            => new RegOp((ushort)kind);

        [MethodImpl(Inline)]
        public static RegOp<T> reg<T>(T src)
            where T : unmanaged, IRegOp
                => new RegOp<T>(src);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => new RegOp(first(span16u(src.Data)));
    }
}