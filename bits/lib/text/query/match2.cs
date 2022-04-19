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
        public static void match(ReadOnlySpan<char> src, char c0, char c1, Action<int> signal)
        {
            var count = src.Length;
            var level = z8;
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
                            signal(i-level);
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