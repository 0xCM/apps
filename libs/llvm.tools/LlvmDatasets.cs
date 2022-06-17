//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider("llvm.datasets")]
    public readonly struct LlvmDatasets
    {
        public const string X86 = "X86.records";

        public const string X86Defs = "X86.records.defs";

        public const string X86DefFields = "X86.records.defs.fields";

        public const string X86Classes = "X86.records.classes";

        public const string X86ClassFields = "X86.records.classes.fields";
    }
}