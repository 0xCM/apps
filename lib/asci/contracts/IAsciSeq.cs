//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IAsciSeq : IByteSeq
    {

    }

    [Free]
    public interface IAsciSeq<S> : IAsciSeq, IBytes<S>, IComparable<S>, IEquatable<S>
        where S : struct, IAsciSeq<S>
    {

    }

    [Free]
    public interface IAsciSeq<S,N> : IAsciSeq<S>, IBytes<S,N>
        where N : unmanaged, ITypeNat
        where S : struct, IAsciSeq<S,N>
    {

    }
}