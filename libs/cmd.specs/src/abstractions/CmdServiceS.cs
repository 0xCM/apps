//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdService<S> : AppService<CmdService<S>>, ICmdService
        where S : CmdService<S>, new()
    {
        public new static S create(IWfRuntime wf)
        {
            var svc = new S();
            svc.Dispatcher = Cmd.dispatcher(svc.Actions);
            svc.Init(wf);
            return svc;
        }

        ICmdDispatcher Dispatcher;

        public CmdActions Actions {get;}

        public CmdService()
        {
           Actions = CmdActions.discover(this);
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

        protected static CmdArg arg(in CmdArgs src, int index)
            => ShellCmd.arg(src, index);
    }
}