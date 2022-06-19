//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static PathPart normalize(PathPart src)
            => src.Text.Replace('\\', '/');

        [MethodImpl(Inline), Op]
        public static PathPart normalize(string src, PathSeparator sep)
        {
            if(sep == PathSeparator.FS)
                return src.Replace('\\', '/');
            else
                return src.Replace('/', '\\');
        }

        [MethodImpl(Inline), Op]
        public static PathPart normalize(PathPart src, PathSeparator sep)
        {
            if(sep == PathSeparator.FS)
                return src.Text.Replace('\\', '/');
            else
                return src.Text.Replace('/', '\\');
        }

        [MethodImpl(Inline), Op]
        public static FilePath normalize(FilePath src, PathSeparator sep)
            => path(normalize(src.Name, sep));

        [MethodImpl(Inline), Op]
        public static FilePath normalize(FolderPath src, PathSeparator sep)
            => path(normalize(src.Name, sep));
    }
}