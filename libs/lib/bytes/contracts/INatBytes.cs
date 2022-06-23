//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INatBytes<F,N> : IByteSeq<F>, IEquatable<F>, INullary<F>
        where N : unmanaged, ITypeNat
        where F : struct, INatBytes<F,N>
    {
        F IContented<F>.Content
            => (F)this;

        int IByteSeq.Capacity
            => Length;

        int IByteSeq.Length
            => (int)default(N).NatValue;

        F INullary<F>.Zero
            => default;
    }
}