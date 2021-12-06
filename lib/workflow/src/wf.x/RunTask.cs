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
        public static CmdResult RunTask<T>(this T cmd, IWfRuntime wf)
            where T : struct, ICmd
        {
            var task = wf.Dispatch(cmd);
            task.Wait();
            return task.Result;
        }
    }
}