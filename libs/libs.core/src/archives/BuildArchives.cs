//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class BuildArchives : AppService<BuildArchives>
    {
        public WsBuildArchive Create(WsVars vars)
            => new WsBuildArchive(Env,vars);
    }
}