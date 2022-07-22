//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IWfEventLog : IWfEventSink, ISink<IAppEvent>, ISink<IAppMsg>, ISink<IWfEvent>, IDisposable
    {

    }
}