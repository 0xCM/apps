//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdService<S> : WfSvc<CmdService<S>>, ICmdService
        where S : CmdService<S>, new()
    {
        public new static S create(IWfRuntime wf)
        {
            var svc = new S();
            svc.Dispatcher = Cmd.dispatcher(svc.Actions, wf.EventLog);
            svc.Init(wf);
            return svc;
        }

        public virtual IDispatcher Dispatcher {get;protected set;}

        public CmdActions Actions {get;}

        public CmdService()
        {
           Actions = CmdActions.discover((S)this);
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
        {
            EmitCommands(Cmd.source(Dispatcher), ExecutingPart.Id);
        }

        public bool Dispatch(ShellCmdSpec cmd)
        {
            var result = Outcome.Success;
            result = Dispatcher.Dispatch(cmd.Name, cmd.Args);
            if(result.Fail)
                Error(result.Message);
            else
            {
                if(text.nonempty(result.Message))
                    Status(result.Message);
            }
            return result;
        }

        public void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(ShellCmd.parse(lines[i].Content));
        }

        protected void LoadProject(string name)
            => Dispatcher?.Dispatch("project", new CmdArg[]{new CmdArg(EmptyString, name)});
    }
}