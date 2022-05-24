//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static EnvFolders;

    using System.Diagnostics;

    public readonly struct SymbolPaths : IFileArchive
    {
        public static SymbolPaths create(in EnvData env)
            => new SymbolPaths(env.CacheRoot + FS.folder(symbols));

        public static SymbolPaths create(FS.FolderPath root)
            => new SymbolPaths(root);

        public FS.FolderPath Root {get;}

        internal SymbolPaths(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath SymbolCacheRoot()
            => Root;

        public FS.FolderPath DefaultSymbolCache()
            => SymbolCacheRoot() + FS.folder(@default);

        public FS.FolderPath DotNetSymbolRoot()
            => SymbolCacheRoot() + FS.folder(dotnet);

        public Index<FS.FolderPath> DotNetSymbolDirs()
            => DotNetSymbolRoot().SubDirs();

        public FS.Files DotNetSymbolFiles(FS.FolderName folder)
            => DotNetSymbolDir(folder).Files(false);

        public FS.FolderPath DotNetSymbolDir(FS.FolderName folder)
            => DotNetSymbolRoot() + folder;

        public FS.FolderPath DotNetSymbolDir(byte major, byte minor, byte revision)
            => DotNetSymbolRoot() + FS.FolderName.version(major, minor, revision);
    }

    public readonly struct DumpArchive : IFileArchive
    {
        public static DumpArchive refs(in EnvData env)
            => new (env.CacheRoot + FS.folder(dumps) + FS.folder(images));

        public static DumpArchive dotnet(in EnvData env)
            => new (refs(env).DumpRoot() + FS.folder(EnvFolders.dotnet));

        public static DumpArchive create()
            => new DumpArchive(FS.dir("j:/dumps"));

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

    public readonly struct DumpPaths
    {
        public static DumpPaths create()
            => create(EnvData.load());

        public static DumpPaths create(in EnvData env)
            => new DumpPaths(FS.dir("j:/dumps"), env.Db + FS.folder(tables) + FS.folder("dumps.tables"));

        public readonly FS.FolderPath InputRoot {get;}

        public readonly FS.FolderPath OutputRoot {get;}

        [MethodImpl(Inline)]
        public DumpPaths(FS.FolderPath input, FS.FolderPath output)
        {
            InputRoot = input;
            OutputRoot = output;
        }

        public DumpArchive DumpArchive()
            => new DumpArchive(DumpRoot());

        public FS.FolderPath OutputDir(ProcDumpIdentity id)
            => OutputRoot + FS.folder(id.Format());

        [MethodImpl(Inline)]
        public FS.FolderPath DumpRoot()
            => InputRoot;

        public ReadOnlySpan<FS.FilePath> DumpFiles()
            => InputRoot.Files(FS.Dmp).Sort();

        public FS.FilePath CurrentDump()
        {
            var files = DumpFiles();
            var count = files.Length;
            if(count != 0)
                return skip(files, count - 1);
            else
                return FS.FilePath.Empty;
        }
    }

    partial interface IEnvPaths
    {
        // FS.FolderPath DumpRoot()
        //     => FS.dir("j:/dumps");

        // SymbolPaths DebugSymbolPaths()
        //     => SP.create(Env);

        // DumpArchive DumpArchive()
        //     => new DumpArchive(FS.dir("j:/dumps"));

        // DumpArchive DumpArchive(FS.FolderPath root)
        //     => new DumpArchive(root);

        // DumpPaths DumpPaths()
        //     => new DumpPaths(FS.dir("j:/dumps"), Env.Db + FS.folder(tables) + FS.folder("dumps.tables"));

        // FS.FilePath DumpPath(string id)
        //     => DumpArchive(FS.dir("j:/dumps")).DumpPath(id);

        // FS.FilePath DumpPath(Process process, Timestamp ts)
        //     => DumpArchive(FS.dir("j:/dumps")).DumpPath(process,ts);

        // FS.FilePath DumpPath(FS.FolderPath dst, Process process, Timestamp ts)
        //     => DumpArchive(dst).DumpPath(process,ts);

        // DumpArchive RefImageDumps()
        //     => DumpArchive(Env.CacheRoot + FS.folder(dumps) + FS.folder(images));

        // DumpArchive DotNetImageDumps()
        //     => DumpArchive(RefImageDumps().DumpRoot() + FS.folder(dotnet));
    }
}