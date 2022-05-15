//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface ISeq : IMeasured, ITextual
    {
        string ITextual.Format()
            => GetType().Name;
    }

    [Free]
    public interface ISeq<T> : ISeq
    {
        ReadOnlySpan<T> View {get;}

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

        bool INullity.IsEmpty
            => View.Length == 0;
    }

    public interface IMutableSeq<T> : ISeq<T>
    {
        Span<T> Edit {get;}


        ReadOnlySpan<T> ISeq<T>.View
            => Edit;

        ref readonly T ISeq<T>.Cell(int index)
            => ref skip(View,index);

        ref readonly T ISeq<T>.Cell(uint index)
            => ref skip(View,index);

        ref readonly T ISeq<T>.First
        {
            [MethodImpl(Inline)]
            get => ref Cell(0);
        }

        ref readonly T ISeq<T>.this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        ref readonly T ISeq<T>.this[uint index]
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

    }

    [Free]
    public interface ISeq<N,T> : ISeq<T>
        where N : unmanaged, ITypeNat
    {
        uint ICounted.Count
            => core.nat32u<N>();
    }
}