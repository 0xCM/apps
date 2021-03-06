//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Jcc32 : IAsmInstruction<Jcc32>
    {
        [MethodImpl(Inline), Op]
        public static Jcc32 define(Jcc32Code code, Disp32 disp)
            => new Jcc32(code, disp);

        [MethodImpl(Inline), Op]
        public static Jcc32 define(Jcc32AltCode code, Disp32 disp)
            => new Jcc32(code, disp);

        readonly byte Data;

        public readonly Disp32 Disp;

        [MethodImpl(Inline)]
        public Jcc32(Jcc32Code code, Disp32 src)
        {
            Data = (byte)code;
            Disp = src;
        }

        [MethodImpl(Inline)]
        public Jcc32(Jcc32AltCode code, Disp32 src)
        {
            Data = bit.enable((byte)code, 7);
            Disp = src;
        }

        bit Alt
        {
            [MethodImpl(Inline)]
            get  =>  bit.test(Data,7);
        }

        public JccKind Kind
        {
            [MethodImpl(Inline)]
            get =>  Alt ? JccKind.Jcc32Alt : JccKind.Jcc32;
        }

        public Hex8 JccCode
        {
            [MethodImpl(Inline)]
            get => Alt ? bits.disable(Data,7) : Data;
        }
    }
}