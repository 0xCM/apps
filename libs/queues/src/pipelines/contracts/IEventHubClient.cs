//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEventHubClient : IWfEventSink
    {
        IEventHub Hub {get;}

        void Connect();
    }
}