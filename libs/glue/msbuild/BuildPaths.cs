//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    internal static class BuildPaths
    {
        public static FS.FilePath project(IEnvPaths src, in WsVars vars)
            => src.Env.ZDev + FS.folder("src") + FS.folder(vars.Project.Format()) + FS.file(string.Format("z0.{0}", vars.Project), FS.CsProj);

        public static FS.FilePath soulution(IEnvPaths src, in WsVars vars)
            => src.Env.ZDev + FS.file(string.Format("z0.{0}", vars.Project), FS.Sln);

        public static FS.FilePath log(IEnvPaths src, in WsVars vars)
            => src.BuildLogPath(FS.file(string.Format("z0.{0}", vars.Project), FS.Log));

   }
}