//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IByteSeq : IHashed, INullity, ISized
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

        Hash32 IHashed.Hash
            => HashCodes.hash(View);

        ref readonly byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Spans.skip(View,i);
        }

        ref readonly byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Spans.skip(View,i);
        }

        uint Convert<T>(Func<byte,T> converter, Span<T> dst)
        {
            var count = (uint)Scalars.min(dst.Length, Length);
            for(var i=0; i<count; i++)
                Spans.seek(dst,i) = converter(this[i]);
            return count;
        }
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