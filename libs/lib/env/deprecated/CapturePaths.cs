//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath CaptureRoot()
            => Env.Db + FS.folder(capture);

        FS.FolderPath CaptureRoot(FS.FolderPath root)
            => root + FS.folder(capture);

        FS.FolderPath ImmCaptureRoot()
            => Env.Db + FS.folder(capture) + FS.folder(imm);

        FS.FolderPath CaptureContextRoot()
            => Env.Db + FS.folder(capture) + FS.folder(context);

        FS.FilePath ContextTable<T>(Timestamp ts)
            where T : struct, IRecord<T>
                => CaptureContextRoot() + FS.file(string.Format("{0}.{1}", Z0.TableId.identify<T>(), ts.Format()), FS.Csv);

        FS.FolderPath AsmCaptureRoot()
            => Env.Db + FS.folder(capture) + FS.folder(asm);

        FS.Files AsmCapturePaths()
            => AsmCaptureRoot().Files(FS.Asm, true);

        FS.Files AsmCapturePaths(PartId part)
            => AsmCapturePaths().Where(f => f.IsOwner(part));

        FS.FilePath AsmCapturePath(ApiHostUri host)
            => AsmCaptureRoot() + PartFolder(host.Part) + ApiFiles.filename(host, FS.Asm);

        FS.FilePath AsmCapturePath(FS.FolderPath root, ApiHostUri host)
            => root + PartFolder(host.Part) +  ApiFiles.filename(host, FS.Asm);
    }
}