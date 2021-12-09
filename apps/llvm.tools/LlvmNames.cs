//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
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

        [LiteralProvider("llvm.projects")]
        public readonly struct Projects
        {
            public const string Canonical = "canonical";

            public const string LlvmModels = "llvm.models";

            public const string ClangModels = "clang.models";

            public const string ClangAlgs = "clang.algs";

            public const string McModels = "mc.models";

            public const string LlvmData = "llvm.data";

            public static string[] ProjectNames
                = new string[]{Canonical,LlvmModels,ClangModels,McModels,ClangAlgs};
        }

        [LiteralProvider("llvm.tools")]
        public readonly struct Tools
        {
            public const string clang = "clang";

            public const string clang_query = "clang-query";

            public const string llvm_dis = "llvm-dis";

            public const string llvm_nm = "llvm-nm";

            public const string llvm_mc = "llvm-mc";

            public const string llc = "llc";

            public const string llvm_objdump ="llvm-objdump";

            public const string llvm_readobj = "llvm-readobj";

            public const string llvm_tblgen = "llvm-tblgen";
        }

        [LiteralProvider("llvm.repo")]
        public readonly struct Repo
        {
            public const string build = nameof(build);
        }

        [LiteralProvider("llvm.queries")]
        public readonly struct Queries
        {
            const string sep = "/";

            const string root = "llvm" + sep;

            const string names = nameof(names);

            public const string @class = root + nameof(@class);

            public const string classes = root + nameof(classes);

            public const string def = root + nameof(def);

            public const string defs = root + nameof(defs);

            public const string classnames = classes + sep + "names";

        }

        public readonly struct TableGenHeaders
        {
            public const string X86Registers = nameof(X86Registers);

            public const string X86Info = nameof(X86Info);
        }

        public readonly struct Entities
        {
            public const string Instruction = nameof(Instruction);

            public const string InstAlias = nameof(InstAlias);

            public const string Intrinsic = nameof(Intrinsic);

            public const string GenericInstruction = nameof(GenericInstruction);
        }
    }
}