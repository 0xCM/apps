//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringTables
    {
        [MethodImpl(Inline), Op]
        public static StringTableSyntax syntax(Identifier ns, Identifier table, Identifier index, ClrEnumKind kind, Identifier indexNs)
            => new StringTableSyntax(ns, table, index, kind, indexNs);

        [MethodImpl(Inline), Op]
        public static StringTableSyntax syntax(Identifier ns, Identifier table)
            => new StringTableSyntax(ns, table);

        [MethodImpl(Inline), Op]
        public static StringTableSyntax syntax(Identifier ns, Identifier table, Identifier @enum, bool parametric = true)
            => new StringTableSyntax(ns, table, @enum, parametric);
    }
}