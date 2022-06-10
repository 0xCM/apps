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

         DbTargets CgTargets(CgTarget dst);

         DbTargets Targets();

         DbTargets Targets(string scope);

         DbSources Sources();

         DbSources Sources(string scope);

         DbTargets Logs(string scope);
    }
}