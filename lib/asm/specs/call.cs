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

    partial class AsmSpecs
    {
        [MethodImpl(Inline), Op]
        public static CallRel32 call(MemoryAddress rip, uint dx)
            => new CallRel32(rip, dx);

        [MethodImpl(Inline), Op]
        public static byte call32(MemoryAddress rip, MemoryAddress dst, ref byte hex)
        {
            const byte OpCode = 0xE8;
            const byte Size = 5;
            var opcode = OpCode;
            seek(hex, 0) = opcode;
            i32(seek(hex, 1)) = asm.disp32(rip + Size, dst);
            return Size;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode call32(MemoryAddress rip, MemoryAddress dst)
        {
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(bytes,15) = call32(rip, dst, ref first(bytes));
            return encoded;
        }
    }
}