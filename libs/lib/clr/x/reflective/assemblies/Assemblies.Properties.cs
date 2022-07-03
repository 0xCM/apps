//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static PropertyInfo[] Properties(this Assembly[] src)
            => src.SelectMany(x => x.Properties());
    }
}