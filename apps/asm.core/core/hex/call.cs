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

    partial class AsmHexSpecs
    {
        [MethodImpl(Inline), Op]
        public static CallRel32 call(MemoryAddress src, Disp32 disp)
            => AsmRel32.call(src, disp);

        [MethodImpl(Inline), Op]
        public static byte call32(MemoryAddress src, MemoryAddress dst, ref byte hex)
        {
            const byte Size = 5;
            seek(hex, 0) = CallRel32.OpCode;
            i32(seek(hex, 1)) = AsmValues.disp32(src + CallRel32.InstSize, dst);
            return Size;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode call32(MemoryAddress src, MemoryAddress dst)
        {
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(bytes,15) = call32(src, dst, ref first(bytes));
            return encoded;
        }
    }
}