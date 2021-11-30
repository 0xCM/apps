//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBytes<F> : IByteSeq
        where F : struct, IBytes<F>
    {
    }

    [Free]
    public interface IBytes<F,N> : IBytes<F>, IEquatable<F>, INullary<F>
        where N : unmanaged, ITypeNat
        where F : struct, IBytes<F,N>
    {
        int IByteSeq.Capacity
            => Length;

        int IByteSeq.Length
            => (int)default(N).NatValue;

        F INullary<F>.Zero
            => default;
    }
}