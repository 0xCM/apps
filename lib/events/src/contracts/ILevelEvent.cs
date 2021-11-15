//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ILevelEvent : IWfEvent
    {
        LogLevel EventLevel {get;}
    }

    [Free]
    public interface ILevelEvent<H> : IWfEvent, IWfEvent<H>
        where H : ILevelEvent<H>, new()
    {

    }

    [Free]
    public interface ILevelEvent<H,T> : ILevelEvent<H>, IWfEvent<H,T>
        where H : ILevelEvent<H,T>, new()
    {

    }

    [Free]
    public interface IErrorEvent : ILevelEvent
    {
        bool IAppEvent.IsError
            => true;
    }
}