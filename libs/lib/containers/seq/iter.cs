//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Seq
    {
        [MethodImpl(Inline)]
        public static void iter<X>(ReadOnlySpan<X> src, Action<X> f)
        {
            for(var i=0; i<src.Length; i++)
                f(skip(src, i));
        }
    }
}