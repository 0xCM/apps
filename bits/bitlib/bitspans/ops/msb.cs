//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static int msb(in BitSpan src)
        {
            var count = src.Length;
            for(var i = count - 1; i >=0; i--)
                if(src[i])
                    return i;
            return 0;
        }
    }
}