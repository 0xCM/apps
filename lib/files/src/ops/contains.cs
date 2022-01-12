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
        public static bool contains(PathPart src, string match)
            => src.Text.Contains(match);
    }
}