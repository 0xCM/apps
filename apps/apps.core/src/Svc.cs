//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class Svc
    {
        public static AppDb AppDb(this IWfRuntime wf)
            => Z0.AppDb.create(wf);

        public static AppServices AppServices(this IWfRuntime wf)
            => Z0.AppServices.create(wf);

        public static ApiServices ApiServices(this IWfRuntime wf)
            => Z0.ApiServices.create(wf);

        public static AppCmdRunner AppCmdRunner(this IWfRuntime wf)
            => Z0.AppCmdRunner.create(wf);
    }
}