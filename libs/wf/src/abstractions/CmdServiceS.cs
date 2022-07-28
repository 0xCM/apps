//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdService<S> : WfSvc<CmdService<S>>, ICmdProvider, ICmdService
        where S : CmdService<S>, new()
    {
        public new static S create(IWfRuntime wf)
        {
            var svc = new S();
            svc.Dispatcher = Cmd.dispatcher(svc, wf.EventLog, svc.Actions);
            svc.Init(wf);
            return svc;
        }

        public virtual IDispatcher Dispatcher {get;protected set;}

        public ICmdActions Actions {get;}

        public CmdService()
        {
           Actions = Cmd.actions((S)this);
        }

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Error(result.Message);
        }

        public void RunCmd(string name, CmdArgs args)
        {
            Dispatcher.Dispatch(name, args);
        }

        [CmdOp("commands")]
        protected void EmitCommands()
            => Cmd.emit(Cmd.catalog(Dispatcher), AppDb.Commands("defs").Path(ExecutingPart.Id.PartName().Format(), FileKind.Csv), EventLog);

        public bool Dispatch(ShellCmdSpec cmd)
            => Dispatcher.Dispatch(cmd.Name, cmd.Args);

        public void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(ShellCmd.parse(lines[i].Content));
        }

        protected void LoadProject(string name)
            => Dispatcher?.Dispatch("project", CmdArgs.create(new CmdArg[]{new CmdArg(EmptyString, name)}));
    }
}