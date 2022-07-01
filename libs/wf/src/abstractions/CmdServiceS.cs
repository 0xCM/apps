//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdService
    {
        public static ActionDispatcher dispatcher<T>(T svc, CmdActions actions)
            where T : ICmdService
                => Cmd.dispatcher(actions);
    }

    public class CmdService<S> : WfSvc<CmdService<S>>, ICmdService
        where S : CmdService<S>, new()
    {
        public new static S create(IWfRuntime wf)
        {
            var svc = new S();
            svc.Dispatcher = Cmd.dispatcher(svc.Actions);
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
            => EmitCommands(AppDb.ApiTargets().Path(FS.file($"api.commands.shell.{controller().Id().Format()}", FS.Csv)));

        protected void EmitCommands(FS.FilePath dst)
        {
            var actions = Dispatcher.Commands.Specs.Index().Sort();
            var emitter = text.emitter();
            iter(actions, cmd => emitter.AppendLine(cmd));
            iter(actions, cmd => Write(cmd));
            FileEmit(emitter.Emit(), actions.Count, dst);
        }

        public bool Dispatch(ShellCmdSpec cmd)
        {
            var result = Outcome.Success;
            try
            {
                result = Dispatcher.Dispatch(cmd.Name, cmd.Args);
                if(result.Fail)
                    Error(result.Message ?? RP.Null);
                else
                {
                    if(text.nonempty(result.Message))
                        Status(result.Message);
                }
            }
            catch(Exception e)
            {
                Error(e);
                result = e;
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