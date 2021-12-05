//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static EnvFolders;

    public readonly struct ApiPackArchives : IFileArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public static ApiPackArchives create(FS.FolderPath root)
            => new ApiPackArchives(root);

        [MethodImpl(Inline)]
        public ApiPackArchives(FS.FolderPath root)
        {
            Root = root;
        }

        public IApiPack Last()
            => Packs().Last;

        public ApiPackArchive Archive(string name)
            => ApiPackArchive.create(Root + FS.folder(name));

        public ApiPackArchive Archive(Timestamp ts)
            => ApiPackArchive.create(Root + FS.folder(ts));

        public Index<IApiPack> Packs()
            => Root.SubDirs(false).Select(x => (IApiPack)(pack(x)));

        static IApiPack pack(FS.FolderPath root)
            => new ApiPack(ApiExtractSettings.init(root));

        public Outcome<Arrow<FS.FolderPath,FS.FolderPath>> Link(Timestamp ts)
        {
            var link = Root + FS.folder(current);
            var target = Root + FS.folder(ts);
            var outcome = FS.symlink(link, target, true);
            if(outcome.Ok)
                return new Arrow<FS.FolderPath,FS.FolderPath>(link, target);
            else
                return outcome;
        }
    }
}