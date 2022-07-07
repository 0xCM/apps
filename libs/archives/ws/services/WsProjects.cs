//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WsProjects : IWsProjects
    {
        [MethodImpl(Inline)]
        public static IWsProjects load(IRootedArchive src)
            => new WsProjects(src.Root);

        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public WsProjects(FS.FolderPath root)
        {
            Root = root;
        }

        [MethodImpl(Inline)]
        public WsProjects(FS.FolderPath root, string scope)
        {
            Root = root + FS.folder(scope);
        }
    }
}