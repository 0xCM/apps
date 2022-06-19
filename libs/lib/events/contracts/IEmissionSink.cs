//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEmissionSink : IEventSink, IDisposable
    {

    }

    [Free]
    public interface IEmissionSink<S> : IEmissionSink
        where S : IEmissionSink<S>
    {

    }
}