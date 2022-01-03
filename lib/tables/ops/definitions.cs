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
        public static Index<TableDef> definitions(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<TableDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = definition(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<TableDef> definitions(params Assembly[] src)
            => definitions(src.Types().Tagged<RecordAttribute>());
    }
}