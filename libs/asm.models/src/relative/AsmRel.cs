//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    [ApiHost]
    public readonly struct AsmRel
    {
        [MethodImpl(Inline)]
        public static Rip rip(MemoryAddress callsite, byte instsize)
            => new Rip(callsite, instsize);

        [MethodImpl(Inline), Op]
        public static AsmOpKind kind(NativeSize size)
            => AsmOps.kind(AsmOpClass.Rel, size);

        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp32(Rip src, MemoryAddress dst)
            => new JmpRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp32(LocatedSymbol src, LocatedSymbol dst)
            => new JmpRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp32(Rip rip, Disp32 disp)
            => new JmpRel32(rip.Address, AsmRel32.target(rip, disp));

        [MethodImpl(Inline), Op]
        public static Disp8 disp8(ReadOnlySpan<byte> encoding)
            => skip(encoding,1);

        public static Disp8 disp8(Rip rip, MemoryAddress dst)
            => (byte)((long)dst - (long)rip);

        [MethodImpl(Inline), Op]
        public static Disp8 disp8(MemoryAddress rip, MemoryAddress dst)
            => (byte)(dst - rip);

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(Rip rip, Disp8 disp)
            => (MemoryAddress)((long)rip + (sbyte)disp);

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(W8 w, MemoryAddress src, ReadOnlySpan<byte> encoding)
        {
            var rip = src + JmpRel8.InstSize;
            var dx = disp8(encoding);
            return rip + dx;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(JmpRel8 spec)
        {
            var encoding = AsmHexCode.Empty;
            var buffer = encoding.Bytes;
            seek(buffer,0) = JmpRel8.OpCode;
            seek(buffer,1) = AsmRel8.disp(spec.SourceAddress + JmpRel8.InstSize, spec.TargetAddress);
            return encoding;
        }
    }
}