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
        public static FolderName folder(PathPart name)
            => new FolderName(name);

        [MethodImpl(Inline), Op]
        public static FolderName folder(PathPart a, PathPart b)
            => folder(a) + folder(b);

        [Op]
        public static FS.FolderName folder(PartId part)
            => folder(part.Format());

        [MethodImpl(Inline), Op]
        public static FolderName folder(Timestamp ts)
            => new FolderName(ts.Format());
    }
}