//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileFlowCmd : ICmd
    {
        IActor Actor {get;}

        FS.FilePath Source {get;}

        FS.FilePath Target {get;}
    }

    public interface IFileFlowCmd<C> : IFileFlowCmd, ICmd<C>
        where C : struct, IFileFlowCmd<C>
    {
    }

    public interface IFileCmdFlow<C>
    {
        C Cmd(IProjectWs project, string scope, FS.FilePath src);
    }

    public interface ICmdScriptBuilder
    {
        CmdScript BuildCmdScript(IFileFlowCmd src);

        Index<CmdLine> BuildCmdLines(IProjectWs project, string cmdsrc, IFileFlowType flowtype);
    }

    public interface ICmdScriptBuilder<F>
    {

    }


    public interface IFileFlowType : IFlowType
    {
        FileKind SourceKind {get;}

        FileKind TargetKind {get;}

        FS.FileExt SourceExt
            => SourceKind.Ext();

        FS.FileExt TargetExt
            => TargetKind.Ext();

        string ITextual.Format()
            => FileFlowType.format(this);
    }

    public interface IFileFlowType<F> : IFileFlowType
        where F : IFileFlowType<F>
    {

    }

    public interface IProjectCmdBuilder<C>
        where C : IFileFlowCmd
    {
        C Cmd(IProjectWs project, string scope, FS.FilePath src);
    }
}