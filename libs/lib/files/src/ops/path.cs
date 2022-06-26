//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FilePath path(string name)
            => new FilePath(normalize(name));

        [MethodImpl(Inline), Op]
        public static FilePath path(FolderPath folder, FileName file)
            => folder + file;

        public static Files query(string pattern)
            =>  Directory.EnumerateFiles(pattern).Map(FS.path);
    }
}