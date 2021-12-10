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
    using static core;

    partial struct Cmd
    {
        [Op]
        public static CmdAction action(string name, ICmdHost host, MethodInfo method)
            => new CmdAction(name,host,method);

        [Op]
        public static Index<CmdAction> actions(ICmdHost host)
        {
            var methods = host.GetType().Methods().Tagged<CmdOpAttribute>();
            var buffer = alloc<CmdAction>(methods.Length);
            actions(host, methods,buffer);
            return buffer;
        }

        static void actions(ICmdHost host, ReadOnlySpan<MethodInfo> src, Span<CmdAction> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = action(tag.CommandName, host, method);
            }
        }
    }
}