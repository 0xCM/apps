//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    partial struct Tables
    {
        [Op]
        public static Index<TableSchema> schemas(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<TableSchema>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = schema(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<TableSchema> schemas(params Assembly[] src)
            => schemas(src.Types().Tagged<RecordAttribute>());
    }
}