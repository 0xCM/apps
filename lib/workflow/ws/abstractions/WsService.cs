//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WsService<T> : AppService<T>, IWsService<T>
        where T : WsService<T>,new()
    {
        protected WsService()
            : base()
        {
            Init((T)this);
        }

        void Init(T svc)
            => svc.Ws = DevWs.create(svc.Env.DevWs);

        protected new DevWs Ws;

        IWorkspace IWsService.Ws
            => Ws;


        protected ProjectScripts ProjectScripts => Service(Wf.ProjectScripts);

    }
}