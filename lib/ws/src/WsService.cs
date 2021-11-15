//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WsService<T> : Service<T>, IWsService<T>
        where T : WsService<T>,new()
    {
        protected WsService()
            : base(Init)
        {

        }

        static void Init(T svc)
        {
            svc.Ws = DevWs.create(svc.Env.DevWs);
        }

        protected DevWs Ws;

        IWorkspace IWsService.Ws
            => Ws;
    }
}