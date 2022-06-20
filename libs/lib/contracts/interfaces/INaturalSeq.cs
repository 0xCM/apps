//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INaturalSeq<N,T> : IMutableSeq<T>
        where N : unmanaged, ITypeNat
    {
        uint ICounted.Count
            => core.nat32u<N>();
    }
}