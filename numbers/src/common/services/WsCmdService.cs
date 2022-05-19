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
        WsCmdRunner CmdExec
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

        public void EmitCommands()
        {
            EmitCommands(Dispatcher);
        }

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