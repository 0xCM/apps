//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Record(TableId)]
    public struct LlvmInstOpCode
    {
        public const string TableId = "llvm.inst.opcode";

        public ushort AsmId;

        public Identifier InstName;

        public Identifier Map;

        public BitString Bits;

        public Hex8 Scalar;
    }
}