//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ActionDispatcher : IDispatcher
    {
        ICmdActions _Actions;

        Func<string,CmdArgs,Outcome> Fallback;

        readonly WfEventLogger Log;

        readonly asci32 Provider;

        [MethodImpl(Inline)]
        public ActionDispatcher(asci32 provider, ICmdActions lookup, WfEventLogger log)
        {
            Provider = provider;
            _Actions = lookup;
            Fallback = NotFound;
            Log = log;
        }

        public ref readonly asci32 ProviderName
        {
            [MethodImpl(Inline)]
            get => ref Provider;
        }

        public ICmdActions Commands => _Actions;

        static Outcome NotFound(string cmd, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", cmd));

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            var result = Outcome.Success;
            var invoker = default(ICmdActionInvoker);
            if(_Actions.Find(name, out invoker))
            {
                result = invoker.Invoke(args);
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