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

    partial struct SymbolicQuery
    {
        [Op]
        public static int match(N5 n, ReadOnlySpan<char> src, ReadOnlySpan<char> target)
        {
            var count = src.Length;
            var level = 0;
            ref readonly var c0 = ref skip(target,0);
            ref readonly var c1 = ref skip(target,1);
            ref readonly var c2 = ref skip(target,2);
            ref readonly var c3 = ref skip(target,3);
            ref readonly var c4 = ref skip(target,4);
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
                            level++;
                    break;
                    case 2:
                        if(SQ.match(c, c2))
                            level++;
                    break;
                    case 3:
                        if(SQ.match(c, c3))
                            level++;
                    break;
                    case 4:
                        if(SQ.match(c, c4))
                            return i-level;
                        level = 0;
                    break;
                    default:
                        level = 0;
                        break;
                }
            }
            return -1;
        }

        [Op]
        public static void match(N5 n, ReadOnlySpan<UnicodeLine> src, TextMarker marker, Action<TextMatch> signal)
        {
            var count = src.Length;
            var seq = span(marker.Content);
            ref readonly var c0 = ref skip(seq,0);
            ref readonly var c1 = ref skip(seq,1);
            ref readonly var c2 = ref skip(seq,2);
            ref readonly var c3 = ref skip(seq,3);
            ref readonly var c4 = ref skip(seq,4);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var chars = span(line.Content);
                var charcount = chars.Length;
                var level = 0;
                for(var j=0u; j<charcount; j++)
                {
                    ref readonly var c = ref skip(chars, j);
                    switch(level)
                    {
                        case 0:
                            if(SQ.match(c, c0))
                                level++;
                        break;
                        case 1:
                            if(SQ.match(c, c1))
                                level++;
                        break;
                        case 2:
                            if(SQ.match(c, c2))
                                level++;
                        break;
                        case 3:
                            if(SQ.match(c, c3))
                                level++;
                        break;
                        case 4:
                            if(SQ.match(c, c4))
                                signal(SQ.matched(marker, new LineOffset(line.LineNumber,(j-4))));
                            level = 0;
                            break;
                        default:
                            level = 0;
                            break;
                    }
                }
            }
        }
    }
}