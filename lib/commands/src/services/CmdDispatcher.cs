//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class CmdDispatcher : ICmdDispatcher
    {
        CmdMethodLookup Lookup;

        object Host;

        Func<string,CmdArgs,Outcome> Fallback;

        internal CmdDispatcher(object host, CmdMethodLookup lookup, Func<string,CmdArgs,Outcome> fallback = null)
        {
            Host = host;
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
                if(Lookup.Find(command, out var method))
                    return (Outcome)method.Invoke(Host, new object[1]{args});
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