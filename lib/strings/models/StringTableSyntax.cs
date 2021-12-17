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

        public Identifier IndexName {get;}

        public ClrEnumKind IndexKind {get;}

        public Identifier IndexNs {get;}

        public StringTableSyntax(Identifier ns, Identifier table, Identifier index, ClrEnumKind kind, Identifier indexns)
        {
            TableNs = ns;
            TableName = table;
            IndexName = index;
            IndexKind = kind;
            IndexNs = indexns;
        }
    }
}