//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    [ApiHost]
    public readonly struct AsmJmp
    {
        const byte Rel8Size = 2;

        public const byte JmpRel8OpCode = 0xEB;

        const byte Rel32Size = 5;

        public const byte JmpRel32OpCode = 0xE9;

        const byte Jmp64MaxSize = 3;

        const byte Jmp64MinSize = 2;

        const byte Jmp64OpCode = 0xFF;

        [MethodImpl(Inline), Op]
        public static bool isRel32Jmp(ReadOnlySpan<byte> encoding)
            => first(encoding) == JmpRel32OpCode;

        [MethodImpl(Inline), Op]
        public static Address32 rel32dx(ReadOnlySpan<byte> encoding)
            => first(recover<uint>(slice(encoding,1, 4)));

        [MethodImpl(Inline), Op]
        public static Address32 rel32target(MemoryAddress ip, ReadOnlySpan<byte> encoding)
        {
            var rip = ip + Rel32Size;
            var dx = rel32dx(encoding);
            return (Address32)(rip + dx);
        }


        [MethodImpl(Inline), Op]
        public static Disp8 rel8dx(ReadOnlySpan<byte> encoding)
            => skip(encoding,1);

        [MethodImpl(Inline), Op]
        public static byte rel8dx(MemoryAddress ip, MemoryAddress target)
        {
            var rip = ip + Rel8Size;
            var dx = (byte)(rip - target);
            return dx;
        }

        [MethodImpl(Inline), Op]
        public static Address8 rel8target(MemoryAddress ip, ReadOnlySpan<byte> encoding)
        {
            var rip = ip + Rel8Size;
            var dx = rel8dx(encoding);
            return (byte)(rip + dx);
        }

        [MethodImpl(Inline), Op]
        public static Address8 rel8offset(MemoryAddress block, MemoryAddress ip, ReadOnlySpan<byte> encoding)
            => (Address8)(rel8target(ip, encoding) - block);


        [MethodImpl(Inline), Op]
        public static bool isJmp64(ReadOnlySpan<byte> src)
            => (src.Length == Jmp64MaxSize && AsmPrefixTests.rex(src) && skip(src,1) == Jmp64OpCode)
            || (src.Length == Jmp64MinSize && first(src) == Jmp64OpCode);

        [MethodImpl(Inline), Op]
        public static r64 jmp64target(ReadOnlySpan<byte> src)
            => AsmPrefixTests.rex(src) ? (RegIndexCode)(skip(src,2) & 0xF) : (RegIndexCode)(skip(src,1) & 0xF);
    }
}