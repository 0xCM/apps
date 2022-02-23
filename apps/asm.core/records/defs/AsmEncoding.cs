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

        public EncodingId Id;

        public MemoryAddress IP;

        public BinaryCode Encoded;

        public byte Size;

        public AsmExpr Asm;

        Hex64 IAsmEncodingRecord.Id
            => Id;

        AsmExpr IAsmEncodingRecord.Asm
            => Asm;

        AsmHexCode IAsmEncodingRecord.Encoded
            => Encoded;

        MemoryAddress IAsmEncodingRecord.IP
            => IP;

        uint ISequential.Seq
            => Seq;
    }
}