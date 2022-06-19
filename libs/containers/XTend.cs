//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XTend
    {
        public static SymCounts<K> Counts<K>(this Symbols<K> src)
            where K : unmanaged
                => new SymCounts<K>(src);
    }
}