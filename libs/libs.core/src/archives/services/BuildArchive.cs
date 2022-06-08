//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BuildArchive : IWsBuildArchive
    {
        public FS.FolderPath Root {get;}

        public ProjectId Project {get;}

        public EnvData Env {get;}

        [MethodImpl(Inline)]
        public BuildArchive(EnvData env, WsVars vars)
        {
            Env =env;
            Project = vars.Project;
            Root = vars.Home;
        }
    }
}