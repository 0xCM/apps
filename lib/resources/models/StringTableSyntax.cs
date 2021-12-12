//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StringTableSyntax
    {
        public Identifier Namespace {get;}

        public Identifier TableName {get;}

        public Identifier IndexName {get;}

        public bool GlobalIndex {get;}

        public StringTableSyntax(Identifier ns, Identifier table, Identifier index, bool globalidx)
        {
            Namespace = ns;
            TableName = table;
            IndexName = index;
            GlobalIndex = globalidx;
        }
    }
}