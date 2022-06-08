//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IService
    {
         DbTargets Projects();

         DbTargets Project(ProjectId name);

         DbTargets ProjectData(ProjectId name);

         DbTargets ProjectDb(ProjectId project, string scope);

         DbTargets CgTargets(CgTarget dst);

         DbTargets Targets();

         DbTargets Targets(string scope);

         DbSources Sources(string scope);

         DbTargets Logs(string scope);

        EnvData IEnvProvider.Env
            => AppData.Env;

    }
}