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
    public readonly partial struct HexLevel
    {
        [MethodImpl(Inline), Op]
        public static IntPtr locate()
            => typeof(HexLevel).TypeHandle.Value;
    }
}