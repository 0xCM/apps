//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Root;

    public partial class XedCmdProvider : AppCmdProvider<XedCmdProvider>
    {
        IntelXed Xed => Service(Wf.IntelXed);

    }

    partial class XTend
    {
        public static XedCmdProvider XedCommands(this IWfRuntime wf)
            => XedCmdProvider.create(wf);
    }
}