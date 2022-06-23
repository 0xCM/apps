//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface IReadOnlySeq<T> : ISeq
    {
        ReadOnlySpan<T> View {get;}

        ReadOnlySpan<T>.Enumerator GetEnumerator()
            => View.GetEnumerator();

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
}