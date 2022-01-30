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
        public static MemoryAddress rip(in AsmCallSite src)
            => rip(src.Caller.Base, src.LocalOffset, src.InstructionSize);

        [MethodImpl(Inline), Op]
        public static MemoryAddress rip(MemoryAddress @base, Address32 offset, byte instsize)
            => @base + offset + instsize;
    }
}