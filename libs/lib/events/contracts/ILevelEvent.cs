//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
}