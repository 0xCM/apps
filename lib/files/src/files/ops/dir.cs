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
        public static FolderPath dir(PathPart name)
            => new FolderPath(normalize(name));

        [MethodImpl(Inline), Op]
        public static FolderPath dir(string name)
            => new FolderPath(normalize(name));
    }
}