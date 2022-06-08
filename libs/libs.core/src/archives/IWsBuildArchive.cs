//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IWsBuildArchive : IWsArchive
    {
        DbTargets Builds()
            => Targets(build);

        DbTargets Builds(string scope)
            => Targets(build).Targets(scope);

        DbTargets BuildLogs()
            => Builds(logs);

        DbTargets Bin()
            => Builds(bin).Targets(Project.Format());

        DbTargets Release()
            => Bin().Targets(release);
    }
}