//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        [MethodImpl(Inline)]
        public static void iter<X>(ReadOnlySpan<X> src, Action<X> f)
        {
            for(var i=0; i<src.Length; i++)
                f(Spans.skip(src, i));
        }
    }
}