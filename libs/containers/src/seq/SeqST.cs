//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class Seq<S,T> : ReadOnlySeq<S,T>, ISeq<T>
        where S : Seq<S,T>
    {
        [MethodImpl(Inline)]
        protected Seq(T[] src)
            : base(src)
        {

        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public new ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public new ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public new ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public new Span<T>.Enumerator GetEnumerator()
            => Edit.GetEnumerator();

    }
}