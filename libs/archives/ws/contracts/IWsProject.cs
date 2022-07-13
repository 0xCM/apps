//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEtlService : IAppService
    {
        void RunEtl();
    }

    public interface IWsProject : IRootedArchive, IProjectWs
    {
        ProjectId Id
            => Project;

        FS.FilePath BuildFlows()
            => Flows.path(this);
    }
}