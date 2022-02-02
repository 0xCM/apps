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
        public static CallRel32 call32(Rip src, Disp32 disp)
            => AsmRel32.call(src, disp);

        [MethodImpl(Inline), Op]
        public static byte call32(Rip src, MemoryAddress dst, ref byte hex)
        {
            const byte Size = 5;
            seek(hex, 0) = CallRel32.OpCode;
            i32(seek(hex, 1)) = AsmRel32.disp(src, dst);
            return CallRel32.InstSize;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode call32(Rip src, MemoryAddress dst)
        {
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(bytes,15) = call32(src, dst, ref first(bytes));
            return encoded;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode call32(CallRel32 spec)
        {
            var encoding = AsmHexCode.Empty;
            var buffer = encoding.Bytes;
            seek(buffer,0) = CallRel32.OpCode;
            @as<Disp32>(seek(buffer,1)) = AsmRel32.disp((spec.SourceAddress, CallRel32.InstSize), spec.TargetAddress);
            seek(buffer,15) = CallRel32.InstSize;
            return encoding;
        }
    }
}