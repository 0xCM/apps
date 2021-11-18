//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INaturalIntegerType : ISizedIntegerType
    {

    }

    public interface INaturalIntegerType<N> : INaturalIntegerType
        where N : unmanaged, ITypeNat
    {
        BitWidth ISizedType.ContentWidth => TypeNats.nat32u<N>();
    }
}