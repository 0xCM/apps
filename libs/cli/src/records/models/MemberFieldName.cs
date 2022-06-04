//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemberFieldName : IRecord<MemberFieldName>
    {
        public const string TableId = "cli.metadata.fieldname";

        public Count Sequence;

        public ByteSize HeapSize;

        public Count Length;

        public Address32 Offset;

        public string Value;

        [MethodImpl(Inline)]
        public MemberFieldName(Count seq, ByteSize heap, Address32 offset, string value)
        {
            Sequence = seq;
            HeapSize = heap;
            Length = value.Length;
            Offset = offset;
            Value = value;
        }
    }
}