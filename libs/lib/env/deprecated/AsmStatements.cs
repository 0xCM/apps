//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath AsmStatementRoot()
            => Env.Db + FS.folder(tables) + FS.folder("asm.statements");

        FS.FolderPath AsmStatementRoot(FS.FolderPath root)
            => root + FS.folder("asm.statements");

        FS.FolderPath AsmStatementDir(PartId part)
            => AsmStatementRoot() + PartFolder(part);

        FS.FolderPath AsmStatementDir(FS.FolderPath root, PartId part)
            => AsmStatementRoot(root) + PartFolder(part);

        FS.FilePath AsmStatementPath(ApiHostUri host, FS.FileExt ext)
            => AsmStatementDir(host.Part) + HostFile(host, ext);

        FS.FilePath AsmStatementPath(FS.FolderPath root, ApiHostUri host, FS.FileExt ext)
            => AsmStatementDir(root, host.Part) + HostFile(host, ext);
    }
}