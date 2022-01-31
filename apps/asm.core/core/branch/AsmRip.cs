//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmRip
    {
        [MethodImpl(Inline), Op]
        public static MemoryAddress from(in AsmCallSite src)
            => calc(src.Caller.Location, src.LocalOffset, src.InstructionSize);

        [MethodImpl(Inline), Op]
        public static MemoryAddress calc(MemoryAddress @base, Address32 offset, byte instsize)
            => @base + offset + instsize;
    }
}