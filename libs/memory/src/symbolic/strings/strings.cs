//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class StringTables
    {
        public static Index<string> strings<K>(ItemList<K,string> src)
            where K : unmanaged
        {
            var count = src.Length;
            var dst = alloc<string>(count);
            for(var i=0; i<count; i++)
                seek(dst, i) = src[i].Value;
            return dst;
        }
    }
}