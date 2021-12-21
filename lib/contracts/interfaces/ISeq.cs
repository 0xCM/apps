//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISeq<T> : IMeasured
    {
        ReadOnlySpan<T> Elements {get;}

        uint ICounted.Count
            => (uint)Elements.Length;

        int IMeasured.Length
            => Elements.Length;

        bool INullity.IsEmpty
            => Elements.Length == 0;
    }

    [Free]
    public interface ISeq<N,T> : ISeq<T>
        where N : unmanaged, ITypeNat
    {
        uint ICounted.Count
            => core.nat32u<N>();
    }
}