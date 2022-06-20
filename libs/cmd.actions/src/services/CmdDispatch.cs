//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdDispatch : AppService<CmdDispatch>, ICmdRouter
    {
        // public static Index<ICmdReactor> reactors(IWfRuntime wf)
        // {
        //     var types = wf.Components.Types();
        //     var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
        //     iter(reactors, r => r.Init(wf));
        //     return reactors;
        // }

        public static CmdDispatch create(IWfRuntime wf, Index<ICmdReactor> reactors)
        {
            var router = new WfCmdRouter(wf);
            router.Enlist(reactors);
            var dst = create(wf);
            dst.Router = router;
            return dst;
        }

        ICmdRouter Router;

        public Task<CmdResult> Dispatch<T>(T cmd)
            where T : struct, ICmd
                => Task.Factory.StartNew(() => Router.Dispatch(cmd));

        public CmdResult Run<T>(T cmd)
            where T : struct, ICmd
                => Dispatch(cmd).Result;

        void ICmdRouter.Enlist(Index<ICmdReactor> reactors)
            => Router.Enlist(reactors);

        ReadOnlySpan<CmdId> ICmdRouter.SupportedCommands
            => Router.SupportedCommands;

        CmdResult ICmdRouter.Dispatch(ICmd cmd)
            => Router.Dispatch(cmd);

        CmdResult ICmdRouter.Dispatch(ICmd cmd, string msg)
            => Router.Dispatch(cmd, msg);
    }
}