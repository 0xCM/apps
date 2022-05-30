//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Cmd
    {
        [Op]
        public static CmdActionInvoker action(string name, object host, MethodInfo method)
            => new CmdActionInvoker(name,host,method);

        [Op]
        public static Index<CmdActionInvoker> actions(object host)
        {
            var methods = host.GetType().Methods().Tagged<CmdOpAttribute>();
            var buffer = alloc<CmdActionInvoker>(methods.Length);
            actions(host, methods,buffer);
            return buffer;
        }

        static void actions(object host, ReadOnlySpan<MethodInfo> src, Span<CmdActionInvoker> dst)
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