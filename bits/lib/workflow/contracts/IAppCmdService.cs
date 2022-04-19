//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppCmdService : IAppService
    {
        void Run();

        ICmdDispatcher Dispatcher {get;}
    }
}