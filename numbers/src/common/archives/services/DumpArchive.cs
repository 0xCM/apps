//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    public readonly struct DumpArchive : IFileArchive
    {
        public FS.FolderPath Root {get;}

        public DumpArchive(FS.FolderPath root)
        {
            Root = root;
        }

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