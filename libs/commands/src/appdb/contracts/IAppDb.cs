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

         DbTargets ProjectDb();

         DbTargets ProjectDb(string name);

         DbTargets ProjectDb(IProjectWs project, string scope);

         DbTargets CgTargets(CgTarget dst);

         DbTargets Targets();

         DbTargets Targets(string scope);

         DbSources Sources(string scope);

         WsDb WsDb(string name);

         DbTargets Logs(string scope);
    }
}