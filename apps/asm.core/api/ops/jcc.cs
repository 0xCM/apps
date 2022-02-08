//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        /// <summary>
        /// Jump near, relative
        /// </summary>
        /// <param name="w">The relative width selector</param>
        /// <param name="rip">The callsite, i.e. the location at which the jmp instruction begins</param>
        /// <param name="target">The target address</param>
        [MethodImpl(Inline), Op]
        public static void jmp32(Rip rip, MemoryAddress target, Span<byte> dst)
        {
            var i=0;
            seek(dst, i++) = JmpRel32.OpCode;
            var disp = AsmRel32.disp(rip,target);
            @as<Disp32>(slice(dst,1, 4)) = disp;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode jmp32(Rip rip, MemoryAddress target)
        {
            var storage = ByteBlock16.Empty;
            var buffer = storage.Bytes;
            jmp32(rip,target, buffer);
            seek(buffer,15) = JmpRel32.InstSize;
            return @as<AsmHexCode>(buffer);
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode jmp32(JmpRel32 spec)
            => jmp32((spec.SourceAddress, JmpRel32.InstSize), spec.TargetAddress);

        [MethodImpl(Inline), Op]
        public static Jcc8 jcc(Jcc8Code code, Disp8 disp)
            => new Jcc8(code, disp);

        [MethodImpl(Inline), Op]
        public static Jcc8 jcc(Jcc8AltCode code, Disp8 disp)
            => new Jcc8(code, disp);

        [MethodImpl(Inline), Op]
        public static Jcc32 jcc(Jcc32Code code, Disp32 disp)
            => new Jcc32(code, disp);

        [MethodImpl(Inline), Op]
        public static Jcc32 jcc(Jcc32AltCode code, Disp32 disp)
            => new Jcc32(code, disp);
    }
}