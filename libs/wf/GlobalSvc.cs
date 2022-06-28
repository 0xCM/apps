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
            where S : ICmdService, new()
                => Commands.Service<S>(wf);

        public static S InjectCmdSvc<S>(S svc)
            where S : ICmdService
                => inject(svc);

        public class GlobalCmdSvc : CmdServices<GlobalCmdSvc>
        {

        }
    }
}