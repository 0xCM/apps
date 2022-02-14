//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StringTableSyntax
    {
        public Identifier TableNs {get;}

        public Identifier TableName {get;}

        public Identifier EnumName {get;}

        public ClrEnumKind EnumKind {get;}

        public Identifier EnumNs {get;}

        public bool Parametric {get;}

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