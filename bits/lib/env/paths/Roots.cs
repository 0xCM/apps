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
            => DbRoot() + FS.folder(bin);

        FS.FolderPath RefDataRoot()
            => DbRoot() + FS.folder(refdata);

        FS.FolderPath ReportRoot()
            => DbRoot() + FS.folder(reports);

        FS.FolderPath SettingsRoot()
            => DbRoot() + FS.folder(settings);

        FS.FileName HostFile(ApiHostUri host, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}", host.Part.Format(), host.HostName), ext);
    }
}