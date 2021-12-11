//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    public class CmdAction
    {
        public string Name {get;}

        public object Host {get;}

        public MethodInfo Method {get;}

        public CmdAction(string name, object host, MethodInfo method)
        {
            Name = Require.nonempty(name);
            Host = Require.notnull(host);
            Method = Require.notnull(method);
        }
    }
}