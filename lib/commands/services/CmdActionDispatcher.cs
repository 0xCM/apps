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

        public ReadOnlySpan<string> Supported
            => Lookup.Specs;

        public Outcome Dispatch(string command)
            => Dispatch(command, CmdArgs.Empty);

        public Outcome Dispatch(string command, CmdArgs args)
        {
            try
            {
                if(Lookup.Find(command, out var action))
                    return (Outcome)action.Method.Invoke(action.Host, new object[1]{args});
                else
                {
                    if(Fallback != null)
                        return Fallback(command,args);
                    else
                        return (false, string.Format("Command '{0}' unrecognized", command));
                }
            }
            catch(Exception e)
            {
                return e;
            }
        }
    }
}