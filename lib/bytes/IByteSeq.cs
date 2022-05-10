//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface IByteSeq : INullity, ITextual
    {
        /// <summary>
        /// The terms presented as a readonly span
        /// </summary>
        ReadOnlySpan<byte> View {get;}

        /// <summary>
        /// The number of bytes allocated for the sequence
        /// </summary>
        int Capacity {get;}

        /// <summary>
        /// Specifies the number of characters that precede a null terminator, if any; otherwise, returns the capacity
        /// </summary>
        int Length {get;}

        uint Size
            => (uint)Capacity;

        ref readonly byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref core.skip(View,i);
        }

        ref readonly byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref core.skip(View,i);
        }

        uint Convert<T>(Func<byte,T> converter, Span<T> dst)
        {
            var count = (uint)min(dst.Length, Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = converter(this[i]);
            return count;
        }
    }

    [Free]
    public interface IByteSeq<F,T> : IMutableBytes, IByteSeq<F>, IEquatable<F>, INullary<F>
        where T : unmanaged
        where F : unmanaged,IByteSeq<F,T>
    {
        int IByteSeq.Capacity
            => Length;

        F INullary<F>.Zero
            => default;
    }

    [Free]
    public interface IByteSeq<F> : IByteSeq, IContented<F>
        where F : IByteSeq
    {
        int IByteSeq.Length
            => Content.Length;

        int IByteSeq.Capacity
            => Content.Capacity;

        ReadOnlySpan<byte> IByteSeq.View
            => Content.View;

        bool INullity.IsEmpty
            => Content.IsEmpty;
    }
}