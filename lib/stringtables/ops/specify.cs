//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class StringTables
    {
        // public static StringTableSpec specify(StringTableSyntax syntax, ListItem<string>[] entries)
        //     => new StringTableSpec(syntax, entries);
        // [Op]
        // public static StringTableSpec specify(Identifier ns, Identifier table, Identifier index, Identifier indexNs, ListItem<string>[] entries)
        //     => new StringTableSpec(syntax(ns, table, index, indexNs), entries);

        // public static StringTableSpec specify(StringTable src)
        // {
        //     var count = src.EntryCount;
        //     var buffer = alloc<ListItem<string>>(count);
        //     ref var dst = ref first(buffer);
        //     for(var i=0u; i<count; i++)
        //         seek(dst,i) = (i, text.format(src[i]));
        //     return specify(src.Syntax.TableNs, src.Syntax.TableName, src.Syntax.IndexName, src.Syntax.IndexNs, buffer);
        // }
    }
}