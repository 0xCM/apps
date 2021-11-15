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
    using SQ = SymbolicQuery;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static int xedni(ReadOnlySpan<char> src, char match)
        {
            var count = src.Length;
            var result = NotFound;
            for(var i=count-1; i>=0; i--)
            {
                ref readonly var c = ref skip(src,i);
                if(c == match)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, ReadOnlySpan<char> match, bool cased = true)
            => src.IndexOf(match, cased ? Cased : NoCase);

        [Op]
        public static int index(ReadOnlySpan<char> src, char c0, char c1)
        {
            var count = src.Length;
            var level = 0;
            var index = -1;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src, i);
                switch(level)
                {
                    case 0:
                        if(SQ.match(c, c0))
                            level++;
                    break;
                    case 1:
                        if(SQ.match(c, c1))
                        {
                            index = i-level;
                            break;
                        }
                    break;
                    default:
                        level = 0;
                        break;
                }
            }
            return index;
        }

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, char match)
            => src.IndexOf(match);

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<C> src, C match)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(skip(src,i) == match)
                    return i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<C> src, char match)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if((char)skip(src,i) == match)
                    return i;
            return NotFound;
        }

    }
}