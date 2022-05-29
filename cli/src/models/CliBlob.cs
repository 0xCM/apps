//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CliBlob
    {
        public const string TableId = "image.blob";

        public Count Sequence;

        public ByteSize HeapSize;

        public Address32 Offset;

        public ByteSize DataSize;

        public BinaryCode Data;
    }
}