//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline)]
        public static mem<T> mem<T>(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            where T : unmanaged, IMemOp<T>
                => new mem<T>(@base, index,scale, disp);
    }
}