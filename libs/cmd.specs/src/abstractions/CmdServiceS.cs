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

        IDispatcher Dispatcher;

        public CmdActions Actions {get;}

        public CmdService()
        {
           Actions = CmdActions.discover<S>((S)this);
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