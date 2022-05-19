//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(RecordId), StructLayout(StructLayout, Pack=1)]
    public struct TableDefRecord
    {
        const string RecordId = "api.tables";

        [Render(8)]
        public uint Seq;

        [Render(36)]
        public TableId TableId;

        [Render(36)]
        public Name TableType;

        [Render(12)]
        public ushort FieldIndex;

        [Render(36)]
        public Name FieldName;

        [Render(1)]
        public Identifier FieldType;
    }
}