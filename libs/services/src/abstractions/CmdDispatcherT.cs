//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class CmdDispatcher<T> : WfSvc<T>
        where T : CmdDispatcher<T>,new()
    {
        public ICmdDispatcher Dispatcher {get; protected set;}

        protected abstract ICmdProvider[] CmdProviders(IWfRuntime wf);

        protected override void OnInit()
        {
            Dispatcher = CmdActions.dispatcher(CmdProviders(Wf), DispatchFallback);
        }

        protected virtual Outcome DispatchFallback(string command, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", command));

        public bool Dispatch(CmdSpec cmd)
        {
            var result = Outcome.Success;
            try
            {
                result = Dispatcher.Dispatch(cmd.Name, cmd.Args);
                if(result.Fail)
                    Error(result.Message ?? RP.Null);
                else
                {
                    if(nonempty(result.Message))
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
    }
}