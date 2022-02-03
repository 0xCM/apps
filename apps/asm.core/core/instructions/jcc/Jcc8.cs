//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Jcc8
    {
        const byte InstSize = 2;

        readonly byte Code;

        readonly bit Alt;

        public readonly LocatedSymbol Source;

        public readonly LocatedSymbol Target;

        [MethodImpl(Inline)]
        public Jcc8(Jcc8Code code, LocatedSymbol src, LocatedSymbol dst)
        {
            Code = (byte)code;
            Alt = 0;
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public Jcc8(Jcc8AltCode code, LocatedSymbol src, LocatedSymbol dst)
        {
            Code = (byte)code;
            Alt = 1;
            Source = src;
            Target = dst;
        }
    }
}