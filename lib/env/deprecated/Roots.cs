//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath DbRoot(FS.FolderPath root)
            => root;

        FS.FolderPath BinaryRoot()
            => Env.Db + FS.folder(bin);

        FS.FolderPath RefDataRoot()
            => Env.Db + FS.folder(refdata);

        FS.FolderPath ReportRoot()
            => Env.Db + FS.folder(reports);

        FS.FolderPath SettingsRoot()
            => Env.Db + FS.folder(settings);

        FS.FileName HostFile(ApiHostUri host, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}", host.Part.Format(), host.HostName), ext);
    }
}