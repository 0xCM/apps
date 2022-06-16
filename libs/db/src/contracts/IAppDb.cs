//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IService
    {
        IDbTargets DbProjects(ProjectId name);

        FS.FilePath ProjectTable<T>(ProjectId project)
            where T : struct;

        IDbTargets EtlTargets(ProjectId id, string scope);

        IDbTargets DbTargets();

        IDbTargets DbTargets(string scope);

        IDbSources DbSources();

        IDbSources DbSources(string scope);

        IDbTargets Logs(string scope);
    }
}