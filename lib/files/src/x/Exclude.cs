//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XFs
    {
        [MethodImpl(Inline), Op]
        public static FS.FilePath[] Exclude(this FS.FilePath[] src, string match)
            => FS.exclude(src,match);
    }
}