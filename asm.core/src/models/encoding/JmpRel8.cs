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

    [ApiHost]
    public readonly struct JmpRel8
    {
        public const byte InstructionSize = 2;

        public const byte OpCode = 0xEB;

        [MethodImpl(Inline), Op]
        public static bool test(ReadOnlySpan<byte> src)
            => src.Length >= InstructionSize && first(src) == OpCode;

        [MethodImpl(Inline), Op]
        public static Address8 dx(ReadOnlySpan<byte> src)
            => skip(src,1);

        [MethodImpl(Inline), Op]
        public static byte dx(MemoryAddress ip, MemoryAddress target)
        {
            var @base = ip + InstructionSize;
            var dx = (byte)(@base - target);
            return dx;
        }

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(MemoryAddress ip, ReadOnlySpan<byte> src)
        {
            var @base = ip + InstructionSize;
            return @base + dx(src);
        }

        [MethodImpl(Inline), Op]
        public static Address8 offset(MemoryAddress block, MemoryAddress ip, ReadOnlySpan<byte> src)
            => (Address8)(target(ip,src) - block);

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(MemoryAddress ip, MemoryAddress target)
        {   var encoding = AsmHexCode.Empty;
            var dst = encoding.Bytes;
            seek(dst,0) = OpCode;
            seek(dst,1) = dx(ip,target);
            return encoding;
        }
    }
}