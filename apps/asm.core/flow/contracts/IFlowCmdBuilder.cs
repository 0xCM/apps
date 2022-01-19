//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlowCmdBuilder
    {
        CmdScript BuildCmdScript(IFileFlowCmd src);

        IFileFlowCmd BuildCmd(IProjectWs project, string scope, IFileFlowType flow, FS.FilePath src);
    }

    public interface IFlowCmdBuilder<C> : IFlowCmdBuilder
        where C : struct, IFileFlowCmd<C>
    {
        CmdScript BuildCmdScript(C src)
            => FlowScriptBuilder<C>.create().BuildCmdScript(src);

        CmdScript IFlowCmdBuilder.BuildCmdScript(IFileFlowCmd src)
            => BuildCmdScript((C)src);
    }


    public interface IFlowCmdBuilder<C,F> : IFlowCmdBuilder<C>
        where C : struct, IFileFlowCmd<C>
        where F : IFileFlowType<F>
    {
        C BuildCmd(IProjectWs project, string scope, F flow, FS.FilePath src);

        IFileFlowCmd IFlowCmdBuilder.BuildCmd(IProjectWs project, string scope, IFileFlowType flow, FS.FilePath src)
            => BuildCmd(project, scope, (F)flow, src);
    }
}