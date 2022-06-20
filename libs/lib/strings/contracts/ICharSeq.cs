//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface ICharSeq : IByteSeq, ICellular
    {
        bool IsBlank {get;}

        bool IsNull {get;}

        ReadOnlySpan<byte> IByteSeq.View
            => Cells;

        // ref byte First
        //     => ref first(Data);

        // new ref byte this[uint i]
        // {
        //     [MethodImpl(Inline)]
        //     get => ref seek(Data,i);
        // }

        // new ref byte this[int i]
        // {
        //     [MethodImpl(Inline)]
        //     get => ref seek(Data,i);
        // }
    }

    [Free]
    public interface ICharSeq<T> : ICharSeq, ICellular<T>
        where T : unmanaged
    {
        // new ref readonly T this[uint i]
        // {
        //     [MethodImpl(Inline)]
        //     get => ref seek(Cells,i);
        // }

        // new ref T this[int i]
        // {
        //     [MethodImpl(Inline)]
        //     get => ref seek(Data,i);
        // }

        // new ref T First
        //     => ref first(Data);

        // ref byte ICharSeq.First
        //     => ref @as<T,byte>(First);

        // Span<byte> ICharSeq.Data
        //     => bytes(Data);

        // byte ICharSeq.CharSize
        //     => (byte)size<T>();
    }

    [Free]
    public interface ICharSeq<S,T> : ICharSeq<T>, IEquatable<S>, IComparable<S>
        where T : unmanaged
        where S : unmanaged, ICharSeq<S,T>
    {

    }
}