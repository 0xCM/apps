//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StringTableSyntax
    {
        [MethodImpl(Inline), Op]
        public static StringTableSyntax define(Identifier ns, Identifier table, Identifier index, ClrEnumKind kind, Identifier indexNs)
            => new StringTableSyntax(ns, table, index, kind, indexNs);

        [MethodImpl(Inline), Op]
        public static StringTableSyntax define(Identifier ns, Identifier table)
            => new StringTableSyntax(ns, table);

        [MethodImpl(Inline), Op]
        public static StringTableSyntax define(Identifier ns, Identifier table, Identifier @enum, bool parametric = true)
            => new StringTableSyntax(ns, table, @enum, parametric);

        public readonly Identifier TableNs;

        public readonly Identifier TableName;

        public readonly Identifier EnumName;

        public readonly ClrEnumKind EnumKind;

        public readonly Identifier EnumNs;

        public readonly bool Parametric;

        public StringTableSyntax(Identifier ns, Identifier table, Identifier @enum, ClrEnumKind kind, Identifier indexns, bool parametric = false)
        {
            TableNs = ns;
            TableName = table;
            EnumName = @enum;
            EnumKind = kind;
            EnumNs = indexns;
            Parametric = parametric;
        }

        public StringTableSyntax(Identifier ns, Identifier table)
        {
            TableNs = ns;
            TableName = table;
            EnumName = EmptyString;
            EnumKind = 0;
            EnumNs = EmptyString;
            Parametric = false;
        }

        public StringTableSyntax(Identifier ns, Identifier table, Identifier @enum, bool parametric)
        {
            TableNs = ns;
            TableName = table;
            EnumName = @enum;
            EnumKind = 0;
            EnumNs = EmptyString;
            Parametric = parametric;
        }
    }
}