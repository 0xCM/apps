//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppCmdDispatcher : IAppCmdDispatcher
    {
        IAppCommands _Actions;

        Func<string,CmdArgs,Outcome> Fallback;

        readonly IWfEventTarget Log;

        readonly asci32 Provider;

        [MethodImpl(Inline)]
        public AppCmdDispatcher(asci32 provider, IAppCommands lookup, IWfEventTarget log)
        {
            Provider = provider;
            _Actions = lookup;
            Fallback = NotFound;
            Log = log;
        }

        public IAppCommands Commands => _Actions;

        static Outcome NotFound(string cmd, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", cmd));

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            var result = Outcome.Success;
            var invoker = default(IAppCmdRunner);
            if(_Actions.Find(name, out invoker))
            {
                result = invoker.Run(args, Log);
            }
            else
            {
                if(Fallback != null)
                    result = Fallback(name, args);
                else
                    result = (false, string.Format("Command '{0}' unrecognized", name));
            }

            return result;
        }
    }
}