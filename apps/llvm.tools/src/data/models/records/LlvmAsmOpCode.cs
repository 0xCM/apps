//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    [Record(TableId)]
    public struct LlvmAsmOpCode : IComparable<LlvmAsmOpCode>
    {
        public const string TableId = "llvm.asm.opcode";

        public ushort AsmId;

        public Identifier InstName;

        public Identifier Map;

        public BitString Bits;

        public Hex8 Scalar;

        public int CompareTo(LlvmAsmOpCode src)
            => AsmId.CompareTo(src.AsmId);
    }
}