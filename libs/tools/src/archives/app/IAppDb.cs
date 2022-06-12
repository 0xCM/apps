//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IService
    {
         ITargetArchive ProjectTargets(ProjectId name);

         ITargetArchive ProjectData(ProjectId name);

         ITargetArchive CgTargets(CgTarget dst);

         ITargetArchive Targets();

         ITargetArchive Targets(string scope);

         ISourceArchive Sources();

         ISourceArchive Sources(string scope);

         ITargetArchive Logs(string scope);
    }
}