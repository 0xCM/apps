//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmEncodingRecord
    {
        public uint Seq;

        public uint DocSeq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public InstructionId InstructionId;

        public MemoryAddress IP;

        public BinaryCode Encoded;

        public byte Size;

        public AsmExpr Asm;

        public DocRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq);
        }

    }
}