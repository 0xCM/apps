//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Threading.Tasks;

    partial class XTend
    {
        public static Task<CmdResult> Dispatch<T>(this T cmd, IWfRuntime wf)
            where T : struct, ICmd
                => wf.Dispatch(cmd);

        public static CmdResult RunDirect<T>(this T cmd, IWfRuntime wf)
            where T : struct, ICmd
                => wf.Execute(cmd);

        public static string Format<C>(this C src)
            where C : struct, ICmd<C>
                => Cmd.format(src);
    }
}