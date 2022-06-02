//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Assets
    {
        [Op]
        public static Index<ResDocInfo> docs(Assembly src)
        {
            var names = src.GetManifestResourceNames().Index();
            var count = names.Length;
            var dst = alloc<ResDocInfo>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new ResDocInfo(names[i]);
            return dst;
        }
    }
}