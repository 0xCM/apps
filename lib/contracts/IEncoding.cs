//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEncoder<S,T>
    {
        uint Encode(ReadOnlySpan<S> src, Span<T> dst);
    }

    [Free]
    public interface IDecoder<T,S>
    {
        void Decode(ReadOnlySpan<T> src, Span<S> dst);
    }

    [Free]
    public interface IEncoding<S,T> : IEncoder<S,T>, IDecoder<T,S>
    {

    }
}