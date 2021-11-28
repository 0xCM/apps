//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEventSink<E> : ISink<E>
        where E : IWfEvent
    {

    }

    [Free]
    public interface IEventSink : IEventSink<IWfEvent>, IDisposable
    {

    }
}