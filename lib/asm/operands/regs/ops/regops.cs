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

    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static uint regops(RegClassCode @class, NativeSizeCode w, Span<RegOp> dst)
        {
            ref var r = ref first(dst);
            var count = AsmRegData.regcount(@class);
            var counter = 0u;
            for(var i=0; i<count; i++)
                seek(r,counter++) = reg((NativeSizeCode)w, @class, (RegIndexCode)i);
            return counter;
        }
    }
}