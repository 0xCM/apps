//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class GlobalServices : AppServices<GlobalServices>
    {
        static ref readonly GlobalCmdSvc Commands => ref GlobalCmdSvc.Instance;

        public static S CmdSvc<S>(IWfRuntime wf)
            where S : CmdService<S>, new()
                => Commands.Service(wf, CmdService<S>.create);

        public static S InjectCmdSvc<S>(S svc)
            where S : ICmdService
                => inject(svc);

        public static IAppCmdServer CmdServer(IWfRuntime wf)
            => Instance.Service<AppCmdServer>(wf);

        public class GlobalCmdSvc : CmdServices<GlobalCmdSvc>
        {

        }
    }

    partial class XTend
    {
        public static IAppCmdServer AppCmdServer(this IWfRuntime wf)
            => GlobalServices.CmdServer(wf);
    }
}