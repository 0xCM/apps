//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiHexRow : IRecord<ApiHexRow>
    {
        public const string TableId = "api.hex";

        public const byte FieldCount = 7;

        public int Seq;

        public int SourceSeq;

        public MemoryAddress Address;

        public int Length;

        public ExtractTermCode TermCode;

        public OpUri Uri;

        public BinaryCode Data;
    }
}