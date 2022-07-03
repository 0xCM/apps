//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface ISeq : IMeasured, IExpr2
    {

    }

    [Free]
    public interface ISeq<S,T> : ISeq<T>
        where S : ISeq<S,T>, new()
    {
        S Alloc(uint count);
    }

    public interface ISeq<T> : IReadOnlySeq<T>
    {
        Span<T> Edit {get;}

        ReadOnlySpan<T> IReadOnlySeq<T>.View
            => Edit;

        ref readonly T IReadOnlySeq<T>.Cell(int index)
            => ref skip(View,index);

        ref readonly T IReadOnlySeq<T>.Cell(uint index)
            => ref skip(View,index);

        ref readonly T IReadOnlySeq<T>.First
        {
            [MethodImpl(Inline)]
            get => ref Cell(0);
        }

        ref readonly T IReadOnlySeq<T>.this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        ref readonly T IReadOnlySeq<T>.this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        [MethodImpl(Inline)]
        new ref T Cell(int index)
            => ref seek(Edit, index);

        [MethodImpl(Inline)]
        new ref T Cell(uint index)
            => ref seek(Edit, index);

        new ref T First
        {
            [MethodImpl(Inline)]
            get => ref Cell(0);
        }

        new ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        new ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        new Span<T>.Enumerator GetEnumerator()
            => Edit.GetEnumerator();

        new Seq<Y> Select<Y>(Func<T,Y> f)
            => Seq.select(View, f);

        Seq<Z> SelectMany<Y,Z>(Func<T,Seq<Y>> lift, Func<T,Y,Z> project)
             => Seq.map(Edit, lift, project);

        Seq<Y> SelectMany<Y>(Func<T,Seq<Y>> lift)
             => Seq.map(Edit, lift);

        new Seq<T> Where(Func<T,bool> predicate)
            => Seq.where(Edit, predicate);
    }
}