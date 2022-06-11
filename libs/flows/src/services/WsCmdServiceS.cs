//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WsCmdService<S> : AppCmdService<S,CmdShellState>
        where S : WsCmdService<S>, new()
    {
        protected IWsCmdRunner CmdRunner => Wf.WsCmdRunner();

        protected CheckRunner CheckRunner => Wf.CheckRunner();

        protected virtual WsContext Context()
            => WsApi.context(CmdRunner.Project());

        [CmdOp("project")]
        protected virtual void LoadProject(CmdArgs args)
            => CmdRunner.LoadProject(args);

        protected void ProjectLoad(string name)
            => Dispatcher.Dispatch("project", new CmdArg[]{new CmdArg(EmptyString, name)});

        [CmdOp("checks/run")]
        protected void ChecksExec()
            => CheckRunner.Run();

        [CmdOp("checks/list")]
        protected void ChecksList()
            => CheckRunner.ListChecks();
    }
}