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

    public interface IWsProject : IRootedArchive, IProjectWs
    {
        ProjectId Id
            => Project;

        FS.FilePath Script(ScriptId id, FileKind kind)
            => Sources(scripts).Path(id, kind);
    }
}