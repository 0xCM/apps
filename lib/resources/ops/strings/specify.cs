//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class StringTables
    {
        [Op]
        public static StringTableSpec specify(Identifier ns, Identifier table, string index, bool globalidx, ListItem<string>[] entries)
            => new StringTableSpec(ns, table, index, globalidx, entries);

        public static StringTableSpec specify(Identifier ns, string idxname, bool globalidx, StringTable src)
        {
            var count = src.EntryCount;
            var buffer = alloc<ListItem<string>>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (i, text.format(src[i]));
            return specify(ns, src.Name, idxname, globalidx, buffer);
        }
    }
}