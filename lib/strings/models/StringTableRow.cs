//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct StringTableRow
    {
        public const string TableId = "stringtables";

        public const byte FieldCount = 3;

        public string TableName;

        public uint EntryIndex;

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

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24,12,8};
    }
}