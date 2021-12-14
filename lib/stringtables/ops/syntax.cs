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
        public static StringTableSyntax syntax(Identifier ns, Identifier table, Identifier index, bool globalidx)
            => new StringTableSyntax(ns, table, index, ClrEnumKind.U32, globalidx);

        [MethodImpl(Inline), Op]
        public static StringTableSyntax syntax(Identifier ns, Identifier table, Identifier index, ClrEnumKind kind,  bool globalidx)
            => new StringTableSyntax(ns, table, index, kind, globalidx);
    }
}