//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [WfService]
    public abstract class GlobalService<H,S> : IAppService<H>
        where H : GlobalService<H,S>, new()
    {
        static H Service;

        protected static S State;

        protected static IWfRuntime Wf;

        IWfRuntime IAppService.Wf
            => Wf;

        protected abstract H Init(out S state);

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static H create(IWfRuntime wf)
        {
            if(Wf == null)
            {
                Wf = wf;
                Service = new H();
                Service.Init(out State);
            }
            return Service;
        }

        public void Init(IWfRuntime wf)
        {
            create(wf);
        }
    }
}