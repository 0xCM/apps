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
        [Op]
        public static bool matches(FS.FileName name, FS.FileExt ext)
            => name.Format().EndsWith(ext.Name, NoCase);
    }
}