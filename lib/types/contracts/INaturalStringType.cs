//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INaturalStringType<N> : IStringType, INaturalType<N>
        where N : unmanaged, ITypeNat
    {
        uint IStringType.Length => Typed.nat32u<N>();
    }

    public interface INaturalStringType<N,T> : INaturalStringType<N>
        where N : unmanaged, ITypeNat
        where T : INaturalStringType<N,T>, new()
    {
    }
}