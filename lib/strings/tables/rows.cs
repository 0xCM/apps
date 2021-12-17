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
            => new StringTableRow(src.Syntax.TableName, index, text.format(src[index]));

        [Op]
        public static uint rows(ItemList<string> src, Span<StringTableRow> dst)
        {
            var entries = src.View;
            var count = (uint)min(entries.Length,dst.Length);
            for(var j=0; j<count; j++)
            {
                ref var row = ref seek(dst,j);
                ref readonly var entry = ref skip(entries,j);
                row.EntryIndex = entry.Key;
                row.EntryName = entry.Value;
                row.TableName = src.Name;
            }
            return count;
        }
    }
}