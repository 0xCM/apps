//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Jcc8
    {
        readonly byte Code;

        readonly bit Alt;

        public readonly Rip Source;

        public readonly MemoryAddress Target;

        [MethodImpl(Inline)]
        public Jcc8(Jcc8Code code, Rip src, MemoryAddress dst)
        {
            Code = (byte)code;
            Alt = 0;
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public Jcc8(Jcc8AltCode code, Rip src, MemoryAddress dst)
        {
            Code = (byte)code;
            Alt = 1;
            Source = src;
            Target = dst;
        }

        public Disp8 Disp
        {
            [MethodImpl(Inline)]
            get => AsmRel8.disp(Source,Target);
        }
    }
}