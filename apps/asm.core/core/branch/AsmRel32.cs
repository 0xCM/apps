//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public readonly struct AsmRel32
    {
        const byte Rel32InstSize = 5;

        [MethodImpl(Inline), Op]
        public static bool isJmp(ReadOnlySpan<byte> encoding)
            => encoding.Length >= JmpRel32.InstSize && first(encoding) == JmpRel32.OpCode;

        [MethodImpl(Inline), Op]
        public static bool isCall(ReadOnlySpan<byte> encoding)
            => encoding.Length >= CallRel32.InstSize && first(encoding) == CallRel32.OpCode;

        [MethodImpl(Inline), Op]
        public static CallRel32 call(MemoryAddress src, MemoryAddress dst)
            => new CallRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static CallRel32 call(LocatedSymbol src, LocatedSymbol dst)
            => new CallRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static CallRel32 call(MemoryAddress src, Disp32 disp)
        {
            var rip = src + CallRel32.InstSize;
            var dst = rip + (int)disp;
            return call(src,dst);
        }

        [MethodImpl(Inline), Op]
        public static CallRel32 call(LocatedSymbol src, Disp32 disp)
            => call(src.Location, disp);


        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp(MemoryAddress src, MemoryAddress dst)
            => new JmpRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp(LocatedSymbol src, LocatedSymbol dst)
            => new JmpRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp(MemoryAddress src, Disp32 disp)
        {
            var rip = src + JmpRel32.InstSize;
            var dst = rip + (int)disp;
            return jmp(src,dst);
        }

        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp(LocatedSymbol src, Disp32 disp)
            => jmp(src.Location, disp);

        [MethodImpl(Inline), Op]
        public static JmpRel32 from(JmpStub src)
            => jmp(src.Entry, src.Target);

        [MethodImpl(Inline), Op]
        public static Disp32 disp(ReadOnlySpan<byte> encoding)
            => first(recover<Disp32>(slice(encoding,1, 4)));

        [MethodImpl(Inline), Op]
        public static Disp32 disp(MemoryAddress src, MemoryAddress dst)
        {
            var rip = src + Rel32InstSize;
            var dx = (long)rip - (long)dst;
            return (Disp32)dx;
        }

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(MemoryAddress src, ReadOnlySpan<byte> encoding)
        {
            var rip = src + Rel32InstSize;
            var dx = disp(encoding);
            return rip + (int)dx;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(JmpRel32 spec)
        {
            var encoding = AsmHexCode.Empty;
            var buffer = encoding.Bytes;
            seek(buffer,0) = JmpRel32.OpCode;
            @as<Disp32>(seek(buffer,1)) = AsmRel32.disp(spec.SourceAddress, spec.TargetAddress);
            return encoding;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(CallRel32 spec)
        {
            var encoding = AsmHexCode.Empty;
            var buffer = encoding.Bytes;
            seek(buffer,0) = CallRel32.OpCode;
            @as<Disp32>(seek(buffer,1)) = AsmRel32.disp(spec.SourceAddress, spec.TargetAddress);
            return encoding;
        }

    }
}