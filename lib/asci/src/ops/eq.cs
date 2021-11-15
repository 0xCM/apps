//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static bool eq(ReadOnlySpan<char> x, ReadOnlySpan<AsciCode> y)
        {
            var count = x.Length;
            if(count != y.Length)
                return false;

            for(var i=0u; i<count; i++)
                if((byte)skip(x,i) != (byte)skip(y,i))
                    return false;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool eq(ReadOnlySpan<AsciCode> x, ReadOnlySpan<char> y)
            => eq(y,x);
    }
}