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
        public static CallRel32 call(MemoryAddress src, MemoryAddress dst)
            => new CallRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static CallRel32 call(LocatedSymbol src, LocatedSymbol dst)
            => new CallRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static CallRel32 call(Rip src, Disp32 disp)
        {
            var dst = (long)src + (int)disp;
            return call(src,(MemoryAddress)dst);
        }

        [MethodImpl(Inline), Op]
        public static CallRel32 call(LocatedSymbol src, Disp32 disp)
            => call((src.Location, CallRel32.InstSize), disp);

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
        public static JmpRel32 from(RawMemberCode src)
            => jmp(src.Entry, src.Target);

        [MethodImpl(Inline), Op]
        public static Disp32 disp(Rip rip, MemoryAddress dst)
            => (Disp32)((long)dst - (long)rip);

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(Rip rip, Disp32 disp)
            => (MemoryAddress)((long)rip + (long)disp);

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(Rip rip, ReadOnlySpan<byte> encoding)
            => (MemoryAddress)((long)rip + (int)AsmHexSpecs.disp32(encoding));
    }
}