//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITypedSeq<T> : IMeasured
    {
        ReadOnlySpan<T> View {get;}

        uint ICounted.Count
            => (uint)View.Length;

        int IMeasured.Length
            => View.Length;

        bool INullity.IsEmpty
            => View.Length == 0;
    }

    [Free]
    public interface ITypedSeq<N,T> : ITypedSeq<T>
        where N : unmanaged, ITypeNat
    {
        uint ICounted.Count
            => core.nat32u<N>();
    }
}
