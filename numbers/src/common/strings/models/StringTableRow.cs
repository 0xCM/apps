//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct StringTableRow
    {
        const string TableId = "stringtables";

        [Render(24)]
        public string TableName;

        [Render(12)]
        public uint EntryIndex;

        [Render(8)]
        public string EntryName;

        [MethodImpl(Inline)]
        public StringTableRow(string table, uint index, string name)
        {
            TableName = table;
            EntryIndex = index;
            EntryName = name;
        }

        public string Format()
            => string.Format("{0}[{1}]='{2}'", TableName, EntryIndex, EntryName);

        public override string ToString()
            => Format();
   }
}