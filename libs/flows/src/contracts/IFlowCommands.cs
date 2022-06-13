//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlowCommands
    {
        Index<CmdLine> BuildCmdLines(IProjectWs project, string scope, string cmdname);

        void Execute(IProjectWs project, CmdDescriptor descriptor, bool clean = false);
    }

    public interface IFlowCommands<C> : IFlowCommands
        where C : struct, IFileFlowCmd<C>
    {
        CmdScript BuildCmdScript(C src);
    }

    public interface IFlowCommands<C,F> : IFlowCommands<C>
        where C : struct, IFileFlowCmd<C>
        where F : IFileFlowType<F>
    {
        F Flow {get;}

        C BuildCmd(IProjectWs project, string scope, FS.FilePath src);
    }
}