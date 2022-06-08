//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public readonly struct ApiFiles
    {
        public static FS.FileName filename(ApiHostUri host, FS.FileExt ext)
            => FS.file(host.Id.Format(), ext);

        public static FS.FileName filename(ApiHostUri host, FS.FileExt a, FS.FileExt b)
            => FS.file(text.concat(host.Id.Format(), a), b);

        [MethodImpl(Inline), Op]
        public static FS.FolderName folder(ApiHostUri host)
            => FS.folder(host.HostName);

        [MethodImpl(Inline), Op]
        public static FS.FolderName folder(PartId part)
            => FS.folder(part.Format());
    }

    public interface ICilPaths : IEnvPaths
    {
        FS.FilePath CilDataPath(FS.FileName name)
            => CilDataRoot() + name;

        FS.FilePath CilDataPath(ApiHostUri host)
            => CilDataPath(ApiFiles.filename(host, FS.IlData));

        FS.FilePath CilDataPath(FS.FolderPath root, ApiHostUri host)
            => root + PartFolder(host.Part) +   HostFile(host, FS.IlData);

        FS.Files CilDataPaths()
            => CilDataRoot().Files(FS.Csv);

        FS.Files CilDataPaths(PartId part)
            => CilDataPaths().Where(f => f.IsOwner(part));

        FS.FolderPath CilCodeRoot()
            => Env.Db + FS.folder(capture) + FS.folder(cil);

        FS.FilePath CilCodePath(FS.FileName name)
            => CilCodeRoot() + name;

        FS.FilePath CilCodePath(ApiHostUri host)
            => CilCodePath(ApiFiles.filename(host, FS.Il));

        FS.FilePath CilCodePath(FS.FolderPath dst, ApiHostUri host)
            => dst +  PartFolder(host.Part) +  HostFile(host, FS.Il);

        FS.Files CilCodePaths()
            => CilCodeRoot().Files(FS.Csv);

        FS.Files CilCodePaths(PartId part)
            => CilCodePaths().Where(f => f.IsOwner(part));
    }

    public readonly struct CilPaths : ICilPaths
    {
        public EnvData Env {get;}

        [MethodImpl(Inline)]
        public CilPaths(EnvData env)
        {
            Env = env;
        }

        [MethodImpl(Inline)]
        public static implicit operator CilPaths(EnvData env)
            => new CilPaths(env);
    }
}