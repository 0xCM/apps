//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class BuildArchives : AppService<BuildArchives>
    {
        public BuildArchive Create(WsVars vars)
            => new BuildArchive(Env,vars);
    }
}