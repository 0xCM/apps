//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AppPaths : IAppPaths
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public AppPaths(FS.FolderPath root)
            => Root = root;

        public static IAppPaths create()
            => new AppPaths(Z0.Env.load().Db.VarValue);
    }
}