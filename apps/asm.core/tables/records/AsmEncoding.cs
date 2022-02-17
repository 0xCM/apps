//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmEncoding : IAsmEncoding
    {
        public uint Seq;

        public Hex64 Id;

        public MemoryAddress IP;

        public BinaryCode Encoded;

        public byte Size;

        public AsmExpr Asm;

        AsmExpr IAsmEncoding.Asm
            => Asm;

        AsmHexCode IAsmEncoding.Encoded
            => Encoded;

        MemoryAddress IAsmEncoding.IP
            => IP;

        uint ISequential.Seq
            => Seq;
    }
}