//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial struct FS
    {
        public static ListedFiles listing(FS.FolderPath root, bool recurse = true)
            => root.Files(recurse).Select(listing).Array();

        public static ListedFiles listing(FS.FolderPath root, bool recurse, params FileKind[] kinds)
            => root.Files(recurse,kinds).Select(listing).Array();

        public static ListedFiles listing(ReadOnlySpan<FS.FilePath> src)
            => src.Select(listing);

        public static ListedFile listing(FS.FilePath src)
        {
            var dst = new ListedFile();
            var info = new FileInfo(src.Name);
            dst.Name = src.FileName;
            dst.Size = ((ByteSize)info.Length).Kb;
            dst.CreateTS = info.CreationTime;
            dst.UpdateTS = info.LastWriteTime;
            dst.Path = src;
            dst.Attributes = info.Attributes;
            return dst;
        }
    }
}