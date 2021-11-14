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
        /// <summary>
        /// Defines an IP offset relative to a specified base address, instruction size and target address
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="size">The size, in bytes, of the call/branch/jmp instruction</param>
        /// <param name="dst">The call/branch/jmp target</param>
        [MethodImpl(Inline), Op]
        public static long disp(MemoryAddress src, byte fxSize, MemoryAddress dst)
            => (long)(dst - (src + fxSize));
    }
}