//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdService<S> : AppService<CmdService<S>>, ICmdService
        where S : CmdService<S>, new()
    {
        public static S create(IWfRuntime wf, CmdActions actions, ICmdDispatcher dispatch)
        {
            var dst = new S();
            dst.Dispatcher = dispatch;
            dst.Actions = actions;
            dst.Init(wf);
            return dst;
        }

        ICmdDispatcher Dispatcher;

        public CmdActions Actions {get;private set;}

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
    }
}