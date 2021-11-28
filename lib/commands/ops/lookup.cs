//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static Root;
    using static core;

    partial struct Cmd
    {
        [Op]
        public static CmdMethodLookup lookup(object host)
        {
            var type = host.GetType();
            var methods = dict<string,MethodInfo>();
            var src = type.InstanceMethods().Tagged<CmdOpAttribute>().Select(x => (x.Name, x));
            foreach(var (name, method) in src)
            {
                if(!methods.TryAdd(name,method))
                    term.warn(string.Format("Duplicate command:{0}", name));
            }

            var lookup = CmdMethodLookup.create();
            foreach(var (name,method) in methods)
            {
                var cmd = method.Tag<CmdOpAttribute>().MapValueOrDefault(m => m.CommandName, method.Name);
                lookup.Add(cmd, method);
            }
            return lookup.Seal();
        }
    }
}