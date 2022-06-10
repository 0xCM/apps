//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IService
    {
         DbTargets ProjectTargets(ProjectId name);

         DbTargets ProjectData(ProjectId name);

         DbTargets ProjectDb(ProjectId project, string scope);

         DbTargets CgTargets(CgTarget dst);

         ref readonly DbTargets Targets();

         DbTargets Targets(string scope);

         ref readonly DbSources Sources();

         DbSources Sources(string scope);

         DbTargets Logs(string scope);

         ref readonly DbSources Control();
    }
}