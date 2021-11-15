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

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base10 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(digit(@base, skip(src, i)))
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base10 @base, ReadOnlySpan<C> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(digit(@base, skip(src, i)))
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base16 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(digit(@base, skip(src, i)))
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int IndexOfFirstDigit(Base16 @base, ReadOnlySpan<C> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(digit(@base, skip(src, i)))
                    return i;
            return NotFound;
        }
    }
}