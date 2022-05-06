//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiQuery
    {
        public static Index<ApiDataType> datatypes(Assembly[] src)
            => ApiDataType.discover(src);
    }
}