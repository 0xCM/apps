//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct FileArchives
    {
        [Op]
        public static ListFilesCmd listcmd(IEnvPaths paths, string label)
        {
            var archive = RuntimeArchive.create();
            var types = array(FS.Dll, FS.Exe, FS.Pdb, FS.Lib, FS.Xml, FS.Json);
            return listcmd(paths,label + ".build-artifacts", archive.Root, types);
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
        public static CmdResult<ListFilesCmd> exec(ListFilesCmd cmd)
        {
            var _list = list(cmd.SourceDir, cmd.Extensions, cmd.EmissionLimit);
            var outcome = emit(_list, cmd.FileUriMode, cmd.TargetPath);
            return outcome ? Cmd.ok(cmd) : Cmd.fail(cmd, outcome.Message);
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
        public static ListedFiles list(FS.FilePath[] src)
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

        public static FS.Files list(FS.FolderPath src, FS.FileExt[] ext, uint limit = 0)
        {
            var list = limit != 0 ? match(src, limit, ext) : match(src, ext);
            return list;
        }

        [Op]
        public static ListedFiles list(FileArchive src, string pattern, bool recurse)
            => list(Directory.EnumerateFiles(src.Root.Name, pattern, option(recurse)).Array().Select(x => FS.path(pattern)));

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

        /// <summary>
        /// Creates an archive that contains csv-formatted image files
        /// </summary>
        /// <param name="wf">The workflow source</param>
        [Op]
        public static IFileArchive tables(IEnvPaths paths)
            => new FileArchive(paths.TableDir<HexCsv>());

        /// <summary>
        /// Creates an archive over the runtime directory
        /// </summary>
        /// <param name="wf">The workflow source</param>
        [Op]
        public static IFileArchive runtime(IEnvPaths paths)
            => new FileArchive(paths.RuntimeRoot());

        /// <summary>
        /// Creates an archive that contains build image artifacts
        /// </summary>
        /// <param name="wf">The workflow source</param>
        [Op]
        public static IFileArchive build(IEnvPaths paths)
            => new FileArchive(paths.BuildArchiveRoot());
    }
}