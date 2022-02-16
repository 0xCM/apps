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

        public MemoryAddress IP;

        public AsmExpr Asm;

        public BinaryCode Code;

        public CorrelationToken CT;

        AsmExpr IAsmEncoding.Asm
            => Asm;

        AsmHexCode IAsmEncoding.Code
            => Code;

        MemoryAddress IAsmEncoding.IP
            => IP;

        uint ISequential.Seq
            => Seq;

        CorrelationToken ICorrelated.CT
            => CT;
    }
}