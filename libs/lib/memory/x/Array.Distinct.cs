//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        public static T[] Distinct<T>(this T[] src)
        {
            var count = src.Length;
            var dst = new HashSet<T>(count);
            for(var i=0; i<count; i++)
                dst.Add(skip(src,i));
            return dst.Array();
        }
    }
}