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
        [MethodImpl(Inline), Op]
        public static CmdOp cmdop(string name, CliToken id)
            => new CmdOp(name,id);

        [Op]
        public static Index<CmdOp> cmdops(Assembly[] src)
        {
            var methods = src.Methods().Tagged<CmdOpAttribute>();
            var buffer = alloc<CmdOp>(methods.Length);
            cmdops(methods,buffer);
            return buffer;
        }

        [Op]
        public static Index<CmdOp> cmdops(Type src)
        {
            var methods = src.Methods().Tagged<CmdOpAttribute>();
            var buffer = alloc<CmdOp>(methods.Length);
            cmdops(methods,buffer);
            return buffer;
        }

        static void cmdops(ReadOnlySpan<MethodInfo> src, Span<CmdOp> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = cmdop(tag.CommandName, method);
            }
        }
    }
}