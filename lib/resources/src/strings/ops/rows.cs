//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class StringTables
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringTableRow row(in StringTable src, uint index)
            => new StringTableRow(src.Name, index, text.format(src[index]));

        [Op]
        public static uint rows(StringTableSpec src, Span<StringTableRow> dst)
        {
            var entries = src.Entries;
            var count = (uint)min(entries.Length,dst.Length);
            for(var j=0; j<count; j++)
            {
                ref var row = ref seek(dst,j);
                ref readonly var entry = ref skip(entries,j);
                row.EntryIndex = entry.Id;
                row.EntryName = entry.Content;
                row.TableName = src.TableName;
            }
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint rows(in StringTable src, uint offset, Span<StringTableRow> dst)
        {
            var j=0u;
            for(var i=offset; i<src.EntryCount && j<dst.Length; i++)
                seek(dst,j++) = row(src,i);
            return j;
        }
    }
}