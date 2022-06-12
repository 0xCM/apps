//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IService
    {
         IDbTargets ProjectTargets(ProjectId name);

         IDbTargets ProjectData(ProjectId name);

         IDbTargets CgTargets(CgTarget dst);

         IDbTargets Targets();

         IDbTargets Targets(string scope);

         IDbSources Sources();

         IDbSources Sources(string scope);

         IDbTargets Logs(string scope);
    }
}