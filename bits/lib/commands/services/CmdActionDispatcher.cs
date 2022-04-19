//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class CmdActionDispatcher : ICmdDispatcher
    {
        public static CmdActionDispatcher discover(ICmdProvider provider, Func<string,CmdArgs,Outcome> fallback = null)
            => new CmdActionDispatcher(CmdActionLookup.discover(provider), fallback);

        public static CmdActionDispatcher discover(ReadOnlySpan<ICmdProvider> providiers, Func<string,CmdArgs,Outcome> fallback = null)
            => new CmdActionDispatcher(CmdActionLookup.discover(providiers), fallback);

        CmdActionLookup Lookup;

        Func<string,CmdArgs,Outcome> Fallback;

        internal CmdActionDispatcher(CmdActionLookup lookup, Func<string,CmdArgs,Outcome> fallback = null)
        {
            Lookup = lookup;
            Fallback = fallback;
        }

        public ReadOnlySpan<string> SupportedActions
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