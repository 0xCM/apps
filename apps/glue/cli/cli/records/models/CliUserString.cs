//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct CliUserString : IRecord<CliUserString>
    {
        public const string TableId = "cli.strings.user";

        public Count Sequence;

        public bool IsSystemString;

        public ByteSize HeapSize;

        public Count Length;

        public Address32 Offset;

        public string Content;

        [MethodImpl(Inline)]
        public CliUserString(Count seq, ByteSize heap, Address32 offset, string data)
        {
            Sequence = seq;
            IsSystemString = false;
            HeapSize = heap;
            Length = data.Length;
            Offset = offset;
            Content = data;
        }
    }
}