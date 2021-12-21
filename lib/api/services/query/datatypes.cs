//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    partial class ApiQuery
    {
        public static Index<ApiDataType> datatypes(Assembly[] src)
        {
            var types = src.Types().Tagged<DataTypeAttribute>();
            var count = types.Length;
            var buffer = alloc<ApiDataType>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var tag = type.Tag<DataTypeAttribute>().Require();
                ref var dst = ref seek(buffer,i);
                dst = new ApiDataType(type.DisplayName(), tag.NameSyntax, type.IsOpenGeneric(), tag.Kind, tag.ContentWidth, tag.StorageWidth);
            }
            return buffer.Sort();
        }
    }
}