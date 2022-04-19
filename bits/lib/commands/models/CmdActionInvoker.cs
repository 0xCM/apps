//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    public class CmdActionInvoker : ICmdActionInvoker
    {
        public Name ActionName {get;}

        public object Host {get;}

        public MethodInfo Method {get;}

        public CmdActionInvoker(string name, object host, MethodInfo method)
        {
            ActionName = Require.nonempty(name);
            Host = Require.notnull(host);
            Method = Require.notnull(method);
        }

        public Outcome Invoke(CmdArgs args)
        {
            var result = Outcome.Success;
            try
            {
                result = (Outcome)Method.Invoke(Host, new object[1]{args});
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }
    }
}