//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IServiceContext
    {
        IEventSink EventSink {get;}

        IAppPaths AppPaths {get;}
    }
}