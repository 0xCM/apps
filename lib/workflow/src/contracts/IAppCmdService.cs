//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppCmdService : IAppService, ICmdDispatcher
    {
        //Outcome Dispatch(CmdSpec cmd);

        void Run();

        ICmdDispatcher Dispatcher {get;}
    }
}