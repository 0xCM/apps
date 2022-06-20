//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface IAsciSeq : ICharSeq
    {

    }

    [Free]
    public interface IAsciSeq<S> : IAsciSeq, IComparable<S>, IEquatable<S>, IHashed<S>, IContented<S>
        where S : IAsciSeq<S>
    {
        ReadOnlySpan<byte> ICellular.Cells
            => Content.View;

        S IContented<S>.Content
            => (S)this;

        int IByteSeq.Length
            => Content.Length;

        int IByteSeq.Capacity
            => Content.Capacity;

        ReadOnlySpan<byte> IByteSeq.View
            => Content.View;

        bool INullity.IsEmpty
            => Content.IsEmpty;
    }

    [Free]
    public interface IAsciSeq<S,N> : IAsciSeq<S>, INatBytes<S,N>
        where S : struct, IAsciSeq<S,N>
        where N : unmanaged, ITypeNat
    {
        S IContented<S>.Content
            => (S)this;

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