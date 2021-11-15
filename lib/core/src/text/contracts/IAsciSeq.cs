//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IAsciSeq : IByteSeq
    {

    }

    [Free]
    public interface IAsciSeq<F> : IAsciSeq, IBytes<F>, IDataTypeComparable<F>
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