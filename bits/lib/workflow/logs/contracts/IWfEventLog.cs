//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IWfEventLog : IEventSink, ISink<IAppEvent>, ISink<IAppMsg>, ISink<IWfEvent>, IDisposable
    {

    }
}