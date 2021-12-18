//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public static class XSvc
    {
        public static XedCmdProvider XedCommands(this IWfRuntime wf)
            => XedCmdProvider.create(wf);

        public static ApiCmdProvider ApiCommands(this IWfRuntime wf)
            => ApiCmdProvider.create(wf);

        public static ProjectCmdProvider ProjectCommands(this IWfRuntime wf)
            => ProjectCmdProvider.create(wf);
    }
}