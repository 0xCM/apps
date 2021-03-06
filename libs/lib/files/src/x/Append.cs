//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XFs
    {
        public static FS.FilePath Path(this Assembly src)
            => FS.path(src.Location);

        public static FS.FolderPath Folder(this Assembly src)
            => src.Path().FolderPath;

        public static void Append(this FS.FilePath dst, params string[] src)
        {
            using var writer = new StreamWriter(dst.EnsureParentExists().Name, true);
            foreach(var line in src)
                writer.WriteLine(line);
        }

        public static void Append(this FS.FilePath dst, string src)
            => File.AppendAllText(dst.Name, src);
    }
}