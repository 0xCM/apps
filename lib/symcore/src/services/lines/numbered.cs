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

    using SQ = SymbolicQuery;

    partial struct Lines
    {
        [MethodImpl(Inline), Op]
        public static bool numbered(ReadOnlySpan<char> src)
        {
            if(src.Length < 9)
                return false;

            if(skip(src,8) != Chars.Colon)
                return false;

            for(var i=0; i<7; i++)
            {
                if(!SQ.digit(base10, skip(src,i)))
                    return false;
            }
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool numbered(ReadOnlySpan<byte> src)
        {
            if(src.Length < 9)
                return false;

            if(skip(src,8) != Chars.Colon)
                return false;

            for(var i=0; i<7; i++)
            {
                if(!SQ.digit(base10, skip(src,i)))
                    return false;
            }
            return true;
        }
    }
}