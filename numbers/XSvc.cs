//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        public static FileCatalog FileCatalog(this IProjectWs ws)
            => Z0.FileCatalog.load(ws);

        public static WsCmdRunner AppCmdRunner(this IWfRuntime wf)
            => Z0.WsCmdRunner.create(wf);

        [Op]
        public static WsProjects WsProjects(this IWfRuntime wf)
            => Z0.WsProjects.create(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => Z0.AppDb.create(wf);

        public static AppServices AppServices(this IWfRuntime wf)
            => Z0.AppServices.create(wf);

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Z0.CheckRunner.create(wf);
    }
}