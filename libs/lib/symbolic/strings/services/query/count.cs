//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Counts the number of character codes in a specified source that match one of the codes in a specified sequence
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="matches">The characters to match</param>
        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<C> src, params C[] matches)
        {
            var count = 0u;
            var tests = @readonly(matches);
            var mcount = tests.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                for(var j=0; j<mcount; j++)
                    if(c == skip(tests,j))
                        mcount++;
            }
            return count;
        }
    }
}