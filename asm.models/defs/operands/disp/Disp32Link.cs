//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Disp32Link
    {
        public static string format(in Disp32Link src)
            => string.Format("{0}h:{1} -> {2}", src.Disp, src.Source, src.Target);

        public Disp32 Disp {get;}

        public MemoryAddress Source {get;}

        public MemoryAddress Target {get;}

        [MethodImpl(Inline)]
        public Disp32Link(Disp32 disp, MemoryAddress src, MemoryAddress dst)
        {
            Disp = disp;
            Source = src;
            Target = dst;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Disp32Link((Disp32 disp, Arrow<MemoryAddress> link) src)
            => new Disp32Link(src.disp, src.link.Source, src.link.Target);
    }
}