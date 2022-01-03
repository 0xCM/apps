//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

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

        public TypeSpec FieldType;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,36,24,12,24,1};
    }
}