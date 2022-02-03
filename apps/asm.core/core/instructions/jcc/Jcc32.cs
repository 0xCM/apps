//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Jcc32
    {
        readonly byte Code;

        readonly bit Alt;

        public readonly Rip Source;

        public readonly MemoryAddress Target;

        [MethodImpl(Inline)]
        public Jcc32(Jcc32Code code, Rip src, MemoryAddress dst)
        {
            Code = (byte)code;
            Alt = 0;
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public Jcc32(Jcc32AltCode code, Rip src, MemoryAddress dst)
        {
            Code = (byte)code;
            Alt = 1;
            Source = src;
            Target = dst;
        }
    }
}