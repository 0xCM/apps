//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IEtlService : IAppService
    {
        void RunEtl();
    }

    public interface IWsCmdRunner : ICmdRunner, IProjectProvider
    {
        void Project(IWsProject ws);

        void LoadProject(CmdArgs args);
    }

    public interface IWsCmdRunner<S> : IWsCmdRunner
        where S : IWsCmdRunner<S>, new()
    {

    }

    public interface IWsProject : IRootedArchive, IProjectWs
    {
        ProjectId Id
            => Project;

        FS.FilePath Script(ScriptId id, FileKind kind)
            => Sources(scripts).Path(id, kind);
    }
}