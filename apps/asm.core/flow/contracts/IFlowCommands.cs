//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlowCommands
    {
        IFileFlowType Flow {get;}

        CmdScript BuildCmdScript(IFileFlowCmd src);

        IFileFlowCmd BuildCmd(IProjectWs project, string scope, FS.FilePath src);

        Index<CmdLine> BuildCmdLines(IProjectWs project, string scope, string cmdname);

        void Execute(IProjectWs project, CmdDescriptor descriptor, bool clean = false);
    }

    public interface IFlowCommands<C> : IFlowCommands
        where C : struct, IFileFlowCmd<C>
    {
        CmdScript BuildCmdScript(C src);

        CmdScript IFlowCommands.BuildCmdScript(IFileFlowCmd src)
            => BuildCmdScript((C)src);
    }

    public interface IFlowCommands<C,F> : IFlowCommands<C>
        where C : struct, IFileFlowCmd<C>
        where F : IFileFlowType<F>
    {
        new F Flow {get;}

        IFileFlowType IFlowCommands.Flow
            => Flow;

        new C BuildCmd(IProjectWs project, string scope, FS.FilePath src);

        IFileFlowCmd IFlowCommands.BuildCmd(IProjectWs project, string scope, FS.FilePath src)
            => BuildCmd(project, scope, src);
    }
}