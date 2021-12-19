//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using A = LLvmActors;

    public class LlvmTools
    {
        public static readonly A.Llc llc = new();

        public static readonly A.LlvmMc llvm_mc = new();

        public static readonly A.LlvmConfig llvm_config = new();

        public static readonly A.Clang clang = new();

        public static readonly A.LlvmObjDump llvm_objdump = new();

        public static readonly A.LlvmTableGen llvm_tblgen = new();

        public static readonly A.LlvmReadObj llvm_readobj = new();

        public static readonly A.LlvmAs llvm_as = new();
    }
}