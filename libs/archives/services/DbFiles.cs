//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct DbFiles
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public DbFiles(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FileName File(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        [Op]
        public static Outcome<FileEmission> emit(FS.Files src, bool uri, FS.FilePath dst)
        {
            var counter  = 0;
            try
            {
                var view = src.View;
                var count = view.Length;
                using var writer = dst.Writer();
                for(var i=0; i<count; i++)
                {
                    ref readonly var file = ref skip(view,i);
                    var line = uri ? file.ToUri().Format() : file.Format();
                    writer.WriteLine(line);
                    counter++;
                }

                return new FileEmission(dst, (int)counter);
            }
            catch(Exception e)
            {
                return e;
            }
        }

        [MethodImpl(Inline), Op]
        public static IFilteredArchive filter(FS.FolderPath root, string filter)
            => new FilteredArchive(root, filter);

        [MethodImpl(Inline), Op]
        public static IFilteredArchive filter(FS.FolderPath root, params FS.FileExt[] ext)
            => new FilteredArchive(root, ext);

        public static Index<FileDescription> describe(FS.Files src)
            => src.Storage.Select(path => describe(path));

        public static FS.Files search(FS.FolderPath src, FS.FileExt[] ext, uint limit = 0)
            => limit != 0 ? match(src, limit, ext) : match(src, ext);

        public static FS.Files match(FS.FolderPath root, uint max, params FS.FileExt[] ext)
        {
            var files = filter(root, ext).Files().Take(max).Array();
            Array.Sort(files);
            return files;
        }

        public static FS.Files match(FS.FolderPath root, params FS.FileExt[] ext)
        {
            var files = filter(root, ext).Files().Array();
            Array.Sort(files);
            return files;
        }

        public static ListedFiles list(FS.FilePath[] src)
            => new ListedFiles(src.Mapi((i,x) => new ListedFile(i,x)));

        public static ListedFiles list(FS.Files src)
            => new ListedFiles(src.Storage.Mapi((i,x) => new ListedFile((uint)i,x)));

        public static ListedFiles list(FS.FolderPath src, FS.FileExt ext, bool recurse = false)
            => src.Files(ext,recurse).Mapi((i,x) => new ListedFile((uint)i, x));

        public static ListedFiles list(FS.FolderPath src, bool recurse = false)
            => src.Files(recurse).Storage.Mapi((i,x) =>new ListedFile((uint)i, x));

        public static ListedFiles list(FS.FolderPath src, string pattern, bool recurse)
            => list(Directory.EnumerateFiles(src.Name, pattern, option(recurse)).Array().Select(x => FS.path(pattern)));

        [MethodImpl(Inline)]
        internal static SearchOption option(bool recurse)
            => recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

        public static FileDescription describe(FS.FilePath src)
        {
            var dst = new FileDescription();
            var info = new FileInfo(src.Name);
            dst.Path = src;
            dst.Attributes = info.Attributes;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Size = info.Length;
            return dst;
        }

        public IDbSources ProjectSources(ProjectId id)
            => new DbSources(Root, id.Format());

        public IDbTargets ProjectData(ProjectId id)
            => new DbTargets(FS.dir($"{Root}/projects"), id.Format());

        public IDbTargets Targets()
            => new DbTargets(Root);

        public IDbTargets Targets(string scope)
            => new DbTargets(Root, scope);

        public IDbSources Sources()
            => new DbSources(Root);

        public IDbSources Sources(string scope)
            => new DbSources(Root, scope);

        public FS.Files Files(bool recursive)
            => Root.Files(recursive);

        public FS.Files Files(FileKind kind, bool recursive = true)
            => Root.Files(kind.Ext(), recursive);

        public FS.Files Files(FS.FileExt ext, bool recursive = true)
            => Root.Files(ext, recursive);

        public ListedFiles List()
            => new ListedFiles(Root.EnumerateFiles(true).Array().Mapi((i,x) => new ListedFile(i,x)));

        public Deferred<FS.FilePath> Enumerate(bool recursive = true)
            => Root.EnumerateFiles(recursive);

        public FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        public static FS.FileName file(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        public FS.FilePath Path(string name, FileKind kind)
            => Root + FS.file(name, kind.Ext());

        public FS.FilePath Path(string @class, string name, FileKind kind)
            => new DbSources(Root, @class).Root + file(@class, name,kind);

        public FS.FilePath Path(FS.FileName file)
            => Root + file;

        public FS.FilePath Table<T>()
            where T : struct
                => Root + Tables.filename<T>();

        public FS.FilePath Table<T>(ProjectId id)
            where T : struct
                => Root + Tables.filename<T>(id.Format());

        public FS.FilePath Table<T>(string prefix)
            where T : struct
                => Root + Tables.filename<T>(prefix);

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DbFiles(FS.FolderPath src)
            => new DbFiles(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath(DbFiles src)
            => src.Root;
    }
}