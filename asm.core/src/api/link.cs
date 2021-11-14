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
        [MethodImpl(Inline), Op]
        public static Disp32Link link(Disp32 disp, MemoryAddress src, MemoryAddress dst)
            => new Disp32Link(disp,src,dst);
    }
}