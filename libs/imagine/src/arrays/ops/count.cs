//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            var k = 0u;
            for(var i=0; i<src.Length; i++)
            {
                if(f(Spans.skip(src,i)))
                    k++;
            }
            return k;
        }
   }
}