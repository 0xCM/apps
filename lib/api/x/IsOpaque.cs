//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XApi
    {
        [MethodImpl(Inline), Op]
        public static bool IsOpaque(this ApiClassKind src)
            => src >= ApiClassKind.Opaque;
    }
}