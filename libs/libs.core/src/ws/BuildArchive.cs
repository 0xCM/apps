//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WsBuildArchive : IWsBuildArchive
    {
        public readonly FS.FolderPath Root {get;}

        public readonly ProjectId Project {get;}

        public readonly EnvData Env {get;}

        [MethodImpl(Inline)]
        public WsBuildArchive(EnvData env, WsVars vars)
        {
            Env =env;
            Project = vars.Project;
            Root = vars.Home;
        }
    }
}