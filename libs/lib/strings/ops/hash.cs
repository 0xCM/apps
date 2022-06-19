//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct strings
    {
        [MethodImpl(Inline), Op]
        public static uint hash(ReadOnlySpan<char> src)
            => alg.hash.marvin(src);
    }
}