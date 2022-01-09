//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider("projects.names")]
    public readonly struct ProjectNames
    {
        public const string Canonical = "canonical";

        public const string LlvmModels = "llvm.models";

        public const string ClangModels = "clang.models";

        public const string ClangAlgs = "clang.algs";

        public const string McModels = "mc.models";

        public const string McRecoded = "mc.recoded";

        public const string LlvmData = "llvm.data";

    }

    public readonly struct LlvmNames
    {
        [LiteralProvider("llvm.datasets")]
        public readonly struct Datasets
        {
            public const string X86 = "X86.records";

            public const string X86Lined = "x86.records.lined";

            public const string X86Defs = "X86.records.defs";

            public const string X86DefFields = "X86.records.defs.fields";

            public const string X86Classes = "X86.records.classes";

            public const string X86ClassFields = "X86.records.classes.fields";
        }

        [LiteralProvider("llvm.tables")]
        public readonly struct TableNames
        {
            public const string OpCodes = "llvm.opcodes";
        }


        [LiteralProvider("llvm.repo")]
        public readonly struct Repo
        {
            public const string build = nameof(build);
        }

        public readonly struct TableGenHeaders
        {
            public const string X86Registers = nameof(X86Registers);

            public const string X86Info = nameof(X86Info);
        }

        public readonly struct ListTypes
        {
            public const string Predicate = nameof(Predicate);
        }

        [LiteralProvider("llvm.entities")]
        public readonly struct Entities
        {
            public const string InstAlias = nameof(InstAlias);

            public const string GenericInstruction = nameof(GenericInstruction);

            public const string RegisterClass = nameof(RegisterClass);

            public const string X86MemOperand = nameof(X86MemOperand);
        }
    }
}