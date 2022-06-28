//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdActionDispatcher :  ICmdDispatcher
    {
        ICmdActions Lookup;

        Func<string,CmdArgs,Outcome> Fallback;

        public CmdActionDispatcher(ICmdActions lookup, Func<string,CmdArgs,Outcome> fallback = null)
        {
            Lookup = lookup;
            Fallback = fallback ?? NotFound;
        }

        static Outcome NotFound(string cmd, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", cmd));

        public IEnumerable<string> SupportedActions
            => Lookup.Specs;

        public Outcome Dispatch(string action)
            => Dispatch(action, CmdArgs.Empty);

        public Outcome Dispatch(string name, CmdArgs args)
        {
            try
            {
                if(Lookup.Find(name, out var invoker))
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