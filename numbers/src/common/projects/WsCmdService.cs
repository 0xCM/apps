//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WsCmdService<S> : AppCmdService<S,CmdShellState>
        where S : WsCmdService<S>, new()
    {
        AppCmdRunner CmdExec
            => Service(Wf.AppCmdRunner);

        IProjectProvider ProjectProvider
            => CmdExec;

        protected virtual WsProjects Projects
            => Service(Wf.WsProjects);

        protected virtual AppServices AppSvc
            => Service(Wf.AppServices);

        protected virtual AppDb AppDb
            => Service(Wf.AppDb);

        protected WsContext Context()
            => Projects.Context(ProjectProvider);

        [CmdOp("project")]
        protected Outcome LoadProject(CmdArgs args)
            => CmdExec.LoadProject(args);

        protected void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        protected void LoadProject(string name)
            => Dispatcher.Dispatch("project", new CmdArg[]{new CmdArg(EmptyString, name)});
    }
}