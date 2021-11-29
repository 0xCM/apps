
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBufferTokenSource
    {
        /// <summary>
        /// Returns the token of an index-identified buffer
        /// </summary>
        ref readonly BufferToken this[BufferSeqId id] {get;}
    }

    [Free]
    public interface IBufferToken : IAddressable
    {
        IntPtr Handle {get;}

        int Size {get;}

        MemoryAddress IAddressable.Address
            => Handle;
    }

    [Free]
    public interface IBufferToken<F> : IBufferToken
        where F : unmanaged
    {

    }
}