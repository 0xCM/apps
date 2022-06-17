//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using X = FS;

    partial interface IEnvPaths
    {
        FS.FilePath BuildLogPath(FS.FileName src)
            => BuildLogRoot() + src;

        FS.FolderPath AppLogDir(string id)
            => AppLogRoot() + FS.folder(id);

        FS.FilePath AppLog(string id)
            => AppLogRoot() + FS.file(id, FS.Log);

        FS.FilePath AppLog(string id, FS.FileExt ext)
            => AppLogRoot() + FS.file(id, ext);

        FS.FilePath CmdLog(ScriptId id)
            => CmdLogRoot() + (id.IsDiscriminated
                ? FS.file(string.Format("{0}-{1}", id.Id, id.Token), X.Log)
                : FS.file(id.Format(), X.Log));
    }
}