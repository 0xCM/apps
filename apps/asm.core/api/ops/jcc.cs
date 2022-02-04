//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
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