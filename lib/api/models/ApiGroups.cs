//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct ApiGroups
    {
        [MethodImpl(Inline), Op]
        public static ApiGroup group(string name)
            => name;
    }
}