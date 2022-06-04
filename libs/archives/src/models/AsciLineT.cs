//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct AsciLine<T>
        where T : unmanaged
    {
        readonly ReadOnlySpan<T> Data;

        [MethodImpl(Inline)]
        public AsciLine(ReadOnlySpan<T> src)
        {
            Data = src;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
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
            get => Data.Length != 0;
        }

        public string Format()
            => AsciLines.format(this);

        public override string ToString()
            => Format();

        public static AsciLine<T> Empty
        {
            [MethodImpl(Inline)]
            get => new AsciLine<T>(core.array<T>());
        }
    }
}