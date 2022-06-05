//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public record struct LlvmAsmOpCode : IComparable<LlvmAsmOpCode>
    {
        public const string TableId = "llvm.asm.opcode";

        [Render(8)]
        public ushort AsmId;

        [Render(24)]
        public Identifier InstName;

        [Render(8)]
        public Identifier Map;

        [Render(8)]
        public BitString Bits;

        [Render(8)]
        public Hex8 Scalar;

        public int CompareTo(LlvmAsmOpCode src)
            => AsmId.CompareTo(src.AsmId);
    }
}