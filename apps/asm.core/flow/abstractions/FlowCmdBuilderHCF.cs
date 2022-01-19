//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [FlowCmdBuilder]
    public abstract class FlowCmdBuilder<H,C,F> : IFlowCmdBuilder<C,F>
        where C : struct, IFileFlowCmd<C>
        where F : IFileFlowType<F>
        where H : FlowCmdBuilder<H,C,F>, new()
    {
        public CmdScript BuildCmdScript(C src)
            => FlowScriptBuilder<C>.create().BuildCmdScript(src);

        public abstract C BuildCmd(IProjectWs project, string scope, F flow, FS.FilePath src);
    }
}