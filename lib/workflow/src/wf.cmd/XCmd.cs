//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Threading.Tasks;

    public static class XCmd
    {
        public static Task<CmdResult> Dispatch<T>(this T cmd, IWfRuntime wf)
            where T : struct, ICmd
                => wf.Dispatch(cmd);

        public static CmdResult RunTask<T>(this T cmd, IWfRuntime wf)
            where T : struct, ICmd
        {
            var task = wf.Dispatch(cmd);
            task.Wait();
            return task.Result;
        }

        public static CmdResult RunDirect<T>(this T cmd, IWfRuntime wf)
            where T : struct, ICmd
                => wf.Execute(cmd);

        public static string Format<C>(this C src)
            where C : struct, ICmd<C>
                => Cmd.format(src);
    }
}