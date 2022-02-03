//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static Jcc8 jcc(Jcc8Code code, Rip src, MemoryAddress dst)
            => new Jcc8(code, src,dst);

        [MethodImpl(Inline), Op]
        public static Jcc8 jcc(Jcc8AltCode code, Rip src, MemoryAddress dst)
            => new Jcc8(code, src,dst);

        [MethodImpl(Inline), Op]
        public static Jcc32 jcc(Jcc32Code code, Rip src, MemoryAddress dst)
            => new Jcc32(code, src,dst);

        [MethodImpl(Inline), Op]
        public static Jcc32 jcc(Jcc32AltCode code, Rip src, MemoryAddress dst)
            => new Jcc32(code, src,dst);
    }
}