//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static EnvFolders;
    using static Root;

    public interface IImmArchive : IFileArchive
    {
        FS.FolderPath[] ImmDirs(PartId part)
            => Root.SubDirs().Where(d => d.Name.EndsWith(part.Format()));

        FS.FolderPath[] ImmDirs(FS.FolderPath root, PartId part)
            => Root.SubDirs().Where(d => d.Name.EndsWith(part.Format()));

        FS.FolderPath[] ImmHostDirs(PartId part)
            => ImmDirs(part).SelectMany(path => path.SubDirs());

        FS.FolderPath[] ImmHostDirs(FS.FolderPath root, PartId part)
            => ImmDirs(root, part).SelectMany(path => path.SubDirs());

        FS.FolderPath[] ImmHostDirs(params PartId[] parts)
            => parts.SelectMany(ImmHostDirs);

        FS.FolderPath[] ImmHostDirs(FS.FolderPath root, params PartId[] parts)
        {
            var dst = core.list<FS.FolderPath>();
            foreach(var p in parts)
                dst.AddRange(ImmHostDirs(root, p));
            return dst.ToArray();
        }

        FS.FolderPath ImmSubDir(FS.FolderName name)
            => (Root + name);

        FS.FolderPath ImmSubDir(FS.FolderPath root, FS.FolderName name)
            => (Root + name);

        FS.FilePath HexImmPath(PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Hex);

        FS.FilePath HexImmPath(FS.FolderPath root, PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(root, FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Hex);

        FS.FilePath AsmImmPath(PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Asm);

        FS.FilePath AsmImmPath(FS.FolderPath root, PartId owner, ApiHostUri host, OpIdentity id, bool refined)
            => ImmSubDir(root, FS.folder(owner.Format(), host.HostName)) + id.ToFileName(refined ? "r" : EmptyString, FS.Asm);
    }

    public readonly struct ImmArchive : IImmArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public ImmArchive(FS.FolderPath src)
        {
            Root = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator ImmArchive(FS.FolderPath src)
            => new ImmArchive(src);
    }
}