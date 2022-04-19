//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsciLine<T>
        where T : unmanaged
    {
        public LineNumber LineNumber {get;}

        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public AsciLine(uint number, T[] src)
        {
            LineNumber = number;
            Data = src;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public int RenderLength
        {
            [MethodImpl(Inline)]
            get => Data.Length + LineNumber.RenderLength;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string Format()
            => Lines.format(this);

        public override string ToString()
            => Format();

        public static AsciLine<T> Empty
        {
            [MethodImpl(Inline)]
            get => new AsciLine<T>(0,core.array<T>());
        }
    }
}