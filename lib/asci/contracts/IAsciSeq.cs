//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IAsciSeq : IByteSeq
    {

    }

    [Free]
    public interface IAsciSeq<F> : IAsciSeq, IBytes<F>, IComparable<F>, IEquatable<F>
        where F : struct, IAsciSeq<F>
    {

    }

    [Free]
    public interface IAsciSeq<F,N> : IAsciSeq<F>, IBytes<F,N>
        where N : unmanaged, ITypeNat
        where F : struct, IAsciSeq<F,N>
    {

    }
}