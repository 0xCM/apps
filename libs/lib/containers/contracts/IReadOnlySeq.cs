//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface IReadOnlySeq<T> : ISeq, IEnumerable<T>
    {
        ReadOnlySpan<T> View {get;}

        bool INullity.IsEmpty
            => View.Length == 0;

        bool INullity.IsNonEmpty
            => View.Length != 0;

        ref readonly T Cell(int index)
            => ref skip(View,index);

        ref readonly T Cell(uint index)
            => ref skip(View,index);

        ref readonly T First
        {
            [MethodImpl(Inline)]
            get => ref Cell(0);
        }

        ref readonly T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        ref readonly T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        uint ICounted.Count
            => (uint)View.Length;

        int IMeasured.Length
            => View.Length;

        new ReadOnlySpan<T>.Enumerator GetEnumerator()
            => View.GetEnumerator();

        ReadOnlySeq<Y> Select<Y>(Func<T,Y> f)
            => Seq.select(View, f);

        ReadOnlySeq<Z> SelectMany<Y,Z>(Func<T,ReadOnlySeq<Y>> lift, Func<T,Y,Z> project)
             => Seq.map(View, lift, project);

        ReadOnlySeq<Y> SelectMany<Y>(Func<T,ReadOnlySeq<Y>> lift)
             => Seq.map(View, lift);

        ReadOnlySeq<T> Where(Func<T,bool> predicate)
            => Seq.where(View, predicate);

        string IExpr2.Format()
            => string.Join(Chars.Comma, View.ToArray());
    }
}