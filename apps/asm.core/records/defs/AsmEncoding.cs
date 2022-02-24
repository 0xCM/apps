//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmEncodingRecord : IAsmEncodingRecord
    {
        public uint Seq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public MemoryAddress IP;

        public BinaryCode Encoded;

        public byte Size;

        public AsmExpr Asm;

        EncodingId IAsmEncodingRecord.EncodingId
            => EncodingId;

        AsmExpr IAsmEncodingRecord.Asm
            => Asm;

        AsmHexCode IAsmEncodingRecord.Encoded
            => Encoded;

        MemoryAddress IAsmEncodingRecord.IP
            => IP;

        uint ISequential.Seq
            => Seq;

        Hex32 IOriginated.OriginId
            => OriginId;
    }
}