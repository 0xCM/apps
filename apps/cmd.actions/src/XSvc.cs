//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public static partial class XSvc
    {
        public static ApiCmdProvider ApiCommands(this IWfRuntime wf)
            => ApiCmdProvider.create(wf);


        public static CheckCmdProvider CheckCommands(this IWfRuntime wf)
            => CheckCmdProvider.create(wf);

        public static CodeGenProvider CodeGenCommands(this IWfRuntime wf)
            => CodeGenProvider.create(wf);

        public static ProjectCmdProvider ProjectCommands(this IWfRuntime wf)
            => ProjectCmdProvider.create(wf);
    }
}