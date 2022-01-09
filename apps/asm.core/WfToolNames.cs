//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider("wf.tools")]
    public readonly struct ToolNames
    {
        public const string clang = "clang";

        public const string clang_query = "clang-query";

        public const string llvm_dis = "llvm-dis";

        public const string llvm_config = "llvm-config";

        public const string llvm_nm = "llvm-nm";

        public const string llvm_mc = "llvm-mc";

        public const string llc = "llc";

        public const string llvm_objdump ="llvm-objdump";

        public const string llvm_readobj = "llvm-readobj";

        public const string llvm_tblgen = "llvm-tblgen";

        public const string llvm_as = "llvm-as";

        public const string llvm_lld = "llvm-lld";
    }
}