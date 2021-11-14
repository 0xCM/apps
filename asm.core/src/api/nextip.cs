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
        public static MemoryAddress nextip(in AsmCallSite src)
            => nextip(src.Caller.Base, src.LocalOffset, src.InstructionSize);

        [MethodImpl(Inline), Op]
        public static MemoryAddress nextip(MemoryAddress @base, Address16 offset, byte currentsize)
            => @base + offset + currentsize;
    }
}