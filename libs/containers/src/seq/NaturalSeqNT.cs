//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class NaturalSeq<N,T> : Seq<NaturalSeq<N,T>,T>
        where T : IEquatable<T>
        where N : unmanaged, ITypeNat
    {
        [MethodImpl(Inline)]
        public NaturalSeq(T[] src)
            : base(src)
        {

        }

        public string Format()
            => string.Join(Chars.Comma, Data.Storage);

        public override string ToString()
            => Format();

        public NaturalSeq<N,T> Reverse()
            => new NaturalSeq<N,T>(Data.Reverse());

        [MethodImpl(Inline)]
        public T[] ToArray()
            => Data;

        [MethodImpl(Inline)]
        public static implicit operator T[](NaturalSeq<N,T> src)
            => src.Data.Storage;

        [MethodImpl(Inline)]
        public static implicit operator Index<T>(NaturalSeq<N,T> src)
            => src.Data;

        public static NaturalSeq<N,T> Empty => new NaturalSeq<N,T>(sys.empty<T>());
    }
}