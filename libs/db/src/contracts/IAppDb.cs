//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb
    {
        IDbSources DbIn();

        IDbSources DbIn(string scope);

        IDbTargets DbOut();

        IDbTargets DbOut(string scope);

        IDbTargets Logs();

        IDbTargets Logs(string scope);

        IDbTargets DbProjects(ProjectId name);

        FS.FilePath ProjectTable<T>(ProjectId project)
            where T : struct;

        IDbTargets EtlTargets(ProjectId id, string scope);

    }
}