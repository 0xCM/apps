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
            => new StringTableSyntax(ns, table, index, kind, indexNs, true);

        [MethodImpl(Inline), Op]
        public static StringTableSyntax define(Identifier ns, Identifier table, bool parametric)
            => new StringTableSyntax(ns, table, parametric);

        [MethodImpl(Inline), Op]
        public static StringTableSyntax define(Identifier ns, Identifier table, Identifier @enum, bool parametric)
            => new StringTableSyntax(ns, table, @enum, parametric);

        public readonly Identifier TableNs;

        public readonly Identifier TableName;

        public readonly Identifier EnumName;

        public readonly ClrEnumKind EnumKind;

        public readonly Identifier EnumNs;

        public readonly bool Parametric;

        public StringTableSyntax(Identifier ns, Identifier table, Identifier @enum, ClrEnumKind kind, Identifier indexns, bool parametric)
        {
            TableNs = ns;
            TableName = table;
            EnumName = @enum;
            EnumKind = kind;
            EnumNs = indexns;
            Parametric = parametric;
        }

        public StringTableSyntax(Identifier ns, Identifier table, bool parametric)
        {
            TableNs = ns;
            TableName = table;
            EnumName = EmptyString;
            EnumKind = 0;
            EnumNs = EmptyString;
            Parametric = parametric;
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