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

    [StructLayout(LayoutKind.Sequential, Size=16, Pack =1)]
    public readonly struct AsmText<T> : IAsmText<T>
        where T : unmanaged
    {
        public StringAddress Source {get;}

        public AsmTextKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmText(StringAddress src, AsmTextKind kind = default)
        {
            Source = src;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => Source.Render(ref i, dst);

        public string Format()
            => AsmText.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmText<T>(StringAddress src)
            => new AsmText<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmText(AsmText<T> src)
            => new AsmText(src.Source, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator AsmText<T>(ReadOnlySpan<char> src)
            => new AsmText<T>(strings.address(src));
    }
}