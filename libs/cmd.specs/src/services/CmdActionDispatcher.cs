//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdActionDispatcher : ICmdDispatcher
    {
        CmdActions _Actions;

        Func<string,CmdArgs,Outcome> Fallback;

        public CmdActionDispatcher(CmdActions lookup, Func<string,CmdArgs,Outcome> fallback = null)
        {
            _Actions = lookup;
            Fallback = fallback ?? NotFound;
        }

        public ref readonly CmdActions Commands => ref _Actions;

        static Outcome NotFound(string cmd, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", cmd));

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            try
            {
                if(_Actions.Find(name, out var invoker))
                    return invoker.Invoke(args);
                else
                {
                    if(Fallback != null)
                        return Fallback(name, args);
                    else
                        return (false, string.Format("Command '{0}' unrecognized", name));
                }
            }
            catch(Exception e)
            {
                return e;
            }
        }
    }
}