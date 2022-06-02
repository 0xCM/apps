//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    using static EnvFolders;

    public class DumpArchive : AppService<DumpArchive>, ITargetArchive<DumpArchive>
    {
        public FS.FolderPath Root => FS.dir("j:/") + FS.folder(dumps);

        public FS.FilePath Table<T>()
            where T : struct
                => Root + Tables.filename<T>();

        public FS.FilePath Table<T>(ProcDumpIdentity id)
            where T : struct
                => Root + Tables.filename<T>(id.Format());

        public FS.FilePath Table<T>(string name, Timestamp ts)
            where T : struct
                => Root + Tables.filename<T>(ProcDumpIdentity.create(name,ts).Format());

        public FS.FolderPath DumpRoot()
            => Root;

        public FS.Files Dumps()
            => DumpRoot().Files(FS.Dmp);

        public FS.FilePath DumpPath(string id)
            => DumpRoot() + FS.file(id, FS.Dmp);

        public FS.FileName DumpFile(Process process, Timestamp ts)
            => FS.file(ProcDumpIdentity.create(process,ts).Format(), FS.Dmp);

        public FS.FilePath DumpPath(Process process, Timestamp ts)
            => DumpRoot() + DumpFile(process, ts);

        public FS.FolderPath DumpDir(byte major, byte minor, byte revision)
            => DumpRoot() + FS.FolderName.version(major, minor, revision);
    }
}