//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(RecordId)]
    public struct TableDefRecord
    {
        public const string RecordId = "api.tables";

        public const byte FieldCount = 6;

        public uint Seq;

        public TableId TableId;

        public Name TableType;

        public ushort FieldIndex;

        public Name FieldName;

        public Identifier FieldType;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,36,36,12,36,1};
    }
}