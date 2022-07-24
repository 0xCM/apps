//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb
    {
        IDbSources DbIn();

        IDbSources DbRoot();

        IDbSources DbIn(string scope);

        IDbTargets DbOut();

        IDbTargets DbOut(string scope);

        IDbTargets Logs();

        IDbTargets Logs(string scope);

        IWsProject EtlSource(ProjectId src);

        IDbTargets EtlTargets(ProjectId src);

        FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct;

        IDbSources Configs();
    }
}