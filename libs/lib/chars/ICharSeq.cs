//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICharSeq : IByteSeq, ICellular
    {
        bool IsBlank {get;}

        bool IsNull {get;}

        ReadOnlySpan<byte> IByteSeq.View
            => Cells;
    }

    [Free]
    public interface ICharSeq<T> : ICharSeq, ICellular<T>
        where T : unmanaged
    {

    }

    [Free]
    public interface ICharSeq<S,T> : ICharSeq<T>, IEquatable<S>, IComparable<S>
        where T : unmanaged
        where S : unmanaged, ICharSeq<S,T>
    {

    }
}