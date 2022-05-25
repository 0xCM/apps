//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public struct SymTableSpec<K>
        where K : unmanaged
    {
        public string IndexName;

        public string TableName;

        public string IndexNs;

        public string TableNs;

        public ClrEnumKind IndexKind;

        public bool Parametric;

        public bool EmitIndex;

        public Index<char> Content;

        public Index<uint> Offsets;

        public ItemList<K,string> Entries;

        public Index<StringTableRow> Rows;

        public Index<string> Strings;
    }
}