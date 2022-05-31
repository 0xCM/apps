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
        protected abstract new IWsCmdRunner CmdRunner {get;}

        protected virtual AppSvcOps AppSvc
            => Service(Wf.AppSvc);

        protected virtual AppDb AppDb
            => Service(Wf.AppDb);

        protected WsContext Context()
            => WsApi.context(CmdRunner.Project());

        [CmdOp("project")]
        protected void LoadProject(CmdArgs args)
            => CmdRunner.LoadProject(args);

        protected void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        protected void ProjectLoad(string name)
            => Dispatcher.Dispatch("project", new CmdArg[]{new CmdArg(EmptyString, name)});

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