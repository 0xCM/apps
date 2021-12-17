//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial class StringTables
    {
        [MethodImpl(Inline), Op]
        public static StringTableSyntax syntax(Identifier ns, Identifier table, Identifier index, ClrEnumKind kind, Identifier indexNs)
            => new StringTableSyntax(ns, table, index, kind, indexNs);
    }
}