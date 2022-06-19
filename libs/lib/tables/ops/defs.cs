//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        [Op]
        public static Index<TableDef> defs(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<TableDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = def(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<TableDef> defs(params Assembly[] src)
            => defs(src.Types().Tagged<RecordAttribute>());
    }
}