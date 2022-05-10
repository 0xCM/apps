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
    public interface IAsciSeq<S> : IAsciSeq, IByteSeq<S>, IComparable<S>, IEquatable<S>
        where S : struct, IAsciSeq<S>
    {
        S IContented<S>.Content
            => (S)this;

    }

    [Free]
    public interface IAsciSeq<S,N> : IAsciSeq<S>, INatBytes<S,N>
        where N : unmanaged, ITypeNat
        where S : struct, IAsciSeq<S,N>
    {
        S IContented<S>.Content
            => (S)this;
    }
}