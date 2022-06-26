//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ReadOnlySeq<T> : ReadOnlySeq<ReadOnlySeq<T>,T>
    {
        [MethodImpl(Inline)]
        public ReadOnlySeq(T[] src)
            : base(src)
        {
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }
        public ref readonly T this[long i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly T this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public string Format()
            => string.Join(Chars.Comma, Data.Storage);

        public override string ToString()
            => Format();

        public ReadOnlySeq<T> Reverse()
            => new ReadOnlySeq<T>(Data.Reverse());

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySeq<T>(T[] src)
            => new ReadOnlySeq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySeq<T>(Index<T> src)
            => new ReadOnlySeq<T>(src.Storage);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(ReadOnlySeq<T> src)
            => src.View;

        public static ReadOnlySeq<T> Empty => new ReadOnlySeq<T>(sys.empty<T>());
    }
}