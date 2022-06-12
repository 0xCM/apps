//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LlvmNames
    {
        [LiteralProvider("llvm.names")]
        public readonly struct Datasets
        {
            public const string X86 = "X86.records";

            public const string X86Defs = "X86.records.defs";

            public const string X86DefFields = "X86.records.defs.fields";

            public const string X86Classes = "X86.records.classes";

            public const string X86ClassFields = "X86.records.classes.fields";
        }

        [LiteralProvider("llvm.names")]
        public readonly struct TableNames
        {
            public const string OpCodes = "llvm.opcodes";
        }

        [LiteralProvider("llvm.names")]
        public readonly struct Repo
        {
            public const string build = nameof(build);
        }

        [LiteralProvider("llvm.names")]
        public readonly struct TableGenHeaders
        {
            public const string X86Registers = nameof(X86Registers);

            public const string X86Info = nameof(X86Info);
        }

        [LiteralProvider("llvm.names")]
        public readonly struct ListTypes
        {
            public const string Predicate = nameof(Predicate);
        }

        [LiteralProvider("llvm.names")]
        public readonly struct Entities
        {
            public const string InstAlias = nameof(InstAlias);

            public const string GenericInstruction = nameof(GenericInstruction);

            public const string RegisterClass = nameof(RegisterClass);

            public const string X86MemOperand = nameof(X86MemOperand);
        }
    }
}