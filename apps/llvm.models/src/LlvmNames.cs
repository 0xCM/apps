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

        [LiteralProvider("llvm.lists")]
        public readonly struct Lists
        {
            public const string AdSize16 = nameof(AdSize16);

            public const string ComplexPattern = nameof(ComplexPattern);

            public const string GCCBuiltin = nameof(GCCBuiltin);

            public const string Instruction = nameof(Instruction);

            public const string LLVMType = nameof(LLVMType);

            public const string ProcResourceKind = nameof(ProcResourceKind);

            public const string Register = nameof(Register);

            public const string SchedMachineModel = nameof(SchedMachineModel);

            public const string RegisterClass = nameof(RegisterClass);

            public const string X86Inst = nameof(X86Inst);
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
            const string sep = "-";

            const string names = nameof(names);

            public const string @class = nameof(@class);

            public const string classes = nameof(classes);

            public const string list = nameof(list);

            public const string def = nameof(def);

            public const string defs = nameof(defs);

            public const string lineage = nameof(lineage);

            public const string fields = nameof(fields);

            public const string class_fields = @class + sep + fields;

            public const string classnames = @class + names;

            public const string defnames = def + names;
        }

        public readonly struct RecordFields
        {
            public const string AsmString = nameof(AsmString);

            public const string isPseudo = nameof(isPseudo);
        }

        public readonly struct RecordClasses
        {
            public const string Instruction = nameof(Instruction);

            public const string InstAlias = nameof(InstAlias);

            public const string AVX512 = nameof(AVX512);

            public const string AsmOperandClass = nameof(AsmOperandClass);

            public const string AssemblerPredicate = nameof(AssemblerPredicate);

            public const string CondCode = nameof(CondCode);

            public const string DAGOperand = nameof(DAGOperand);

            public const string GenericInstruction = nameof(GenericInstruction);

            public const string Register = nameof(Register);

            public const string RegisterClass = nameof(RegisterClass);

            public const string ValueType = nameof(ValueType);

            public const string X86Inst = nameof(X86Inst);

            public const string Map = nameof(Map);

            public const string Predicate = nameof(Predicate);

            public const string SDPatternOperator = nameof(SDPatternOperator);

            public const string SDNode = nameof(SDNode);

            public const string SubtargetFeature = nameof(SubtargetFeature);

            public const string X86MemOperand = nameof(X86MemOperand);

            public const string X86MemOffsOperand = nameof(X86MemOffsOperand);

            public static string[] Names = new string[]{
                AVX512, AsmOperandClass, AssemblerPredicate, CondCode, DAGOperand,
                Instruction, GenericInstruction, Register, RegisterClass,
                ValueType, X86Inst, Map, Predicate, SDPatternOperator, SDNode,
                SubtargetFeature, X86MemOperand, X86MemOffsOperand,
                };
        }
    }
}