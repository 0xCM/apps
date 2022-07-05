//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    //using static core;

    partial class Spans
    {
        [MethodImpl(Inline)]
        public static bool equal<T,C>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, C comparer)
            where C : IEqualityComparer<T>
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            if(count == 0)
                return true;

            for(var i=0; i<count; i++)
                if(!comparer.Equals(skip(a,i), skip(b,i)))
                    return false;

            return true;
        }
    }
}