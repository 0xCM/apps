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
        public static CmdImplMap<string> implmap(Assembly[] src)
        {
            var dst = new CmdImplMap<string>();
            var methods = src.Methods().Tagged<CmdOpAttribute>();
            var count = methods.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(methods,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                dst[tag.CommandName] = method;
            }
            return dst;
        }
    }
}