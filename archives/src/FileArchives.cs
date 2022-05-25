//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct FileArchives
    {
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

        public static Index<FileDescription> describe(FS.Files src)
            => src.Map(describe);

        /// <summary>
        /// Creates an archive over both managed and unmanaged modules
        /// </summary>
        /// <param name="root">The archive root</param>
        [MethodImpl(Inline), Op]
        public static ModuleArchive modules(FS.FolderPath root)
            => new ModuleArchive(root);

        public static IRuntimeArchive runtime()
            => new RuntimeArchive(FS.dir(RuntimeEnvironment.GetRuntimeDirectory()));

        public static IRuntimeArchive runtime(FS.FolderPath src)
            => new RuntimeArchive(src);

        public static IRuntimeArchive runtime(Assembly src)
            => new RuntimeArchive(FS.path(src.Location).FolderPath);

        public static FS.Files search(FS.FolderPath src, FS.FileExt[] ext, uint limit = 0)
            => limit != 0 ? match(src, limit, ext) : match(src, ext);

        [Op]
        public static ListFilesCmd listcmd(IEnvPaths paths, string label)
        {
            var archive = runtime();
            var types = array(FS.Dll, FS.Exe, FS.Pdb, FS.Lib, FS.Xml, FS.Json);
            return listcmd(paths, label, archive.Root, types);
        }

        [Op]
        public static ListFilesCmd listcmd(IEnvPaths paths, string name, FS.FolderPath src, params FS.FileExt[] kinds)
        {
            var cmd = new ListFilesCmd();
            cmd.ListName = name;
            cmd.SourceDir = src;
            cmd.Extensions = kinds;
            cmd.TargetPath = paths.List(name, FS.Csv);
            cmd.ListFormat = ListFormatKind.Markdown;
            return cmd;
        }

        [Op]
        public static CmdResult<ListFilesCmd,FS.Files> exec(ListFilesCmd cmd)
        {
            var _list = search(cmd.SourceDir, cmd.Extensions, cmd.EmissionLimit);
            var outcome = emit(_list, cmd.FileUriMode, cmd.TargetPath);
            return outcome ? Cmd.ok(cmd,_list) : Cmd.fail(cmd, outcome.Message);
        }

        [Op]
        public static FS.Files match(FS.FolderPath root, uint max, params FS.FileExt[] ext)
        {
            var files = filtered(root, ext).Files().Take(max).Array();
            Array.Sort(files);
            return files;
        }

        [Op]
        public static FS.Files match(FS.FolderPath root, params FS.FileExt[] ext)
        {
            var files = filtered(root, ext).Files().Array();
            Array.Sort(files);
            return files;
        }

        [Op]
        public static ListedFiles listed(FS.FilePath[] src)
            => new ListedFiles(src.Mapi((i,x) => new ListedFile(i,x)));

        [Op]
        public static ListedFiles list(FS.Files src)
            => new ListedFiles(src.Storage.Mapi((i,x) => new ListedFile((uint)i,x)));

        [Op]
        public static ListedFiles list(FS.FolderPath src, FS.FileExt ext, bool recurse = false)
            => src.Files(ext,recurse).Mapi((i,x) => new ListedFile((uint)i, x));

        [Op]
        public static ListedFiles list(FS.FolderPath src, bool recurse = false)
            => src.Files(recurse).Storage.Mapi((i,x) =>new ListedFile((uint)i, x));


        [Op]
        public static ListedFiles list(FileArchive src, string pattern, bool recurse)
            => listed(Directory.EnumerateFiles(src.Root.Name, pattern, option(recurse)).Array().Select(x => FS.path(pattern)));

        [MethodImpl(Inline), Op]
        public static IFileArchive create(FS.FolderPath root)
            => new FileArchive(root);

        [MethodImpl(Inline), Op]
        public static IFilteredArchive filtered(FS.FolderPath root, string filter)
            => new FilteredArchive(root, filter);

        [MethodImpl(Inline), Op]
        public static IFilteredArchive filtered(FS.FolderPath root, params FS.FileExt[] ext)
            => new FilteredArchive(root, ext);

        [MethodImpl(Inline)]
        internal static SearchOption option(bool recurse)
            => recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

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
    }
}