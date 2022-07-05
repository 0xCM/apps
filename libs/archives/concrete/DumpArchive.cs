//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    using static EnvFolders;

    public interface IDumpArchive : IRootedArchive
    {
        IDbTargets DumpTargets(string scope)
            => new DbTargets(Root, scope);

        IDbTargets DotNetTargets()
            => DumpTargets(dotnet);

        FS.FolderPath DotNetTargets(byte major, byte minor, byte revision)
            => DotNetTargets().Targets(FS.FolderName.version(major, minor, revision).Format()).Root;

        FS.Files MiniDumps()
            => Root.Files(FS.Dmp);

        FS.FilePath MiniDump(string name)
            => Root + FS.file(name, FS.Dmp);

        FS.FileName DumpFile(Process process, Timestamp ts)
            => FS.file(ProcDumpName.create(process,ts).Format(), FS.Dmp);

        FS.FilePath DumpPath(Process process, Timestamp ts)
            => Root + DumpFile(process, ts);

        FS.FilePath Table<T>(ProcDumpName id)
            where T : struct
                => Root + Tables.filename<T>(id.Format());

        FS.FilePath Table<T>(string name, Timestamp ts)
            where T : struct
                => Root + Tables.filename<T>(ProcDumpName.create(name,ts).Format());
    }

    public class DumpArchive : AppService<DumpArchive>, IDumpArchive
    {
        public static IDumpArchive Service => new DumpArchive();

        public DumpArchive()
        {
            Root = AppDb.Service.Archives().Sources(dumps).Root;
        }

        public FS.FolderPath Root {get;}
    }
}