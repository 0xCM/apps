//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class WsCmdService<S> : AppCmdService<S,CmdShellState>
        where S : WsCmdService<S>, new()
    {
        static IWsCmdRunner CmdExec;

        protected virtual WsProjects Projects {get; private set;}

        protected virtual void ProjectSelected(IProjectWs ws)
        {

        }

        protected override void OnInit()
        {
            if(CmdExec == null)
            {
                var runner = WsCmdRunner.create(Wf);
                runner.ProjectSelected += ProjectSelected;
                CmdExec = runner;
            }
            Projects = WsProjects.create(Wf);
            base.OnInit();
        }

        protected virtual AppServices AppSvc
            => Service(Wf.AppServices);

        protected virtual AppDb AppDb
            => Service(Wf.AppDb);

        // protected WsContext Context(string project)
        //     => WsContext.create(CmdExec, project);

        protected WsContext Context()
            => WsContext.create(this, CmdExec.Project().Project);

        [CmdOp("project")]
        protected void LoadProject(CmdArgs args)
            => CmdExec.LoadProject(args);

        protected void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        protected void ProjectLoad(string name)
        {
            Dispatcher.Dispatch("project", new CmdArg[]{new CmdArg(EmptyString, name)});
        }

        public void EmitCommands()
            => EmitCommands(Dispatcher);

        [CmdOp(".commands")]
        protected Outcome EmitShellCommands(CmdArgs args)
        {
            EmitCommands();
            return true;
        }

        void EmitCommands(ICmdDispatcher dispatcher)
            => EmitCommands(dispatcher, AppDb.Targets("api").Path(FS.file($"api.{GetType().Name.ToLower()}.cmd", FS.Csv)));

        void EmitCommands(ICmdDispatcher dispatcher, FS.FilePath dst)
        {
            iter(dispatcher.SupportedActions, cmd => Write(cmd));
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            iter(dispatcher.SupportedActions, cmd => writer.WriteLine(cmd));
            EmittedFile(emitting, dispatcher.SupportedActions.Length);
        }
    }
}