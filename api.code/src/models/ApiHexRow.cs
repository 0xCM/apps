//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiHexRow
    {
        const string TableId = "api.hex";

        public const byte FieldCount = 7;

        public uint Seq;

        public uint SourceSeq;

        public MemoryAddress Address;

        public uint CodeSize;

        public ExtractTermCode TermCode;

        public OpUri Uri;

        public BinaryCode Data;

        public static ApiHexRow Empty => default;
    }
}