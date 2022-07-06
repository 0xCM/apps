//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class ReadOnlySeq<S,T> : IReadOnlySeq<T>, IEnumerable<T>
        where S : ReadOnlySeq<S,T>, new()
    {
        protected Index<T> Data;

        [MethodImpl(Inline)]
        protected ReadOnlySeq(T[] src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        protected ReadOnlySeq()
        {
            Data = sys.empty<T>();
        }

        public virtual uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public virtual bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public virtual bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public virtual ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref readonly T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ReadOnlySpan<T>.Enumerator GetEnumerator()
            => View.GetEnumerator();

        public ReadOnlySeq<Y> Select<Y>(Func<T,Y> f)
            => Seq.select(View, f);

        public ReadOnlySeq<Z> SelectMany<Y,Z>(Func<T,ReadOnlySeq<Y>> lift, Func<T,Y,Z> project)
             => Seq.map(View, lift, project);

        public ReadOnlySeq<Y> SelectMany<Y>(Func<T,ReadOnlySeq<Y>> lift)
             => Seq.map(View, lift);

        public ReadOnlySeq<T> Where(Func<T,bool> predicate)
            => Seq.where(View, predicate);

        public void Iter(Action<T> f)
            => Seq.iter(View, f);

        public virtual string Delimiter => "\r\n\t";

        public virtual Fence<char>? Fence => (Chars.LBrace,Chars.RBrace);

        public virtual int CellPad => 0;

        public virtual string Format()
        {
            var content = text.delimit(Data.View, Delimiter, CellPad);
            var dst = content;
            if(Fence != null)
                dst = text.enclose(content, Fence.Value);
            return dst;
        }

        public override string ToString()
            => Format();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => (Data as IIndex<T>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => (Data as IIndex<T>).GetEnumerator();

        public static S Empty => new ();
    }
}