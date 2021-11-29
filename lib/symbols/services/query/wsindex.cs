//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Returns the index of the first whitespace character, if any
        /// </summary>
        /// <param name="src">The content to search</param>
        [MethodImpl(Inline), Op]
        public static int wsindex(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var found = NotFound;
            for(var i=0; i<count; i++)
            {
                if(whitespace(core.skip(src,i)))
                {
                    found = i;
                    break;
                }
            }
            return found;
        }
    }
}