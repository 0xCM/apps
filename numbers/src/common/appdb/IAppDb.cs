//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppDb : IAppService
    {
         DbTargets Projects();

         DbTargets Project(string name);

         DbTargets CgTarget(CgTarget dst);

         DbTargets Targets();

         DbTargets Targets(string scope);

         DbSources Sources(string scope);
    }
}