//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

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
}