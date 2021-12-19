//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using N = LlvmNames.Tools;

    public readonly struct LlvmTools
    {
        public static readonly Llc llc = Llc.Instance;

        public static readonly LlvmMc llvm_mc = LlvmMc.Instance;

        public static readonly LlvmConfig llvm_config = LlvmConfig.Instance;

        public static readonly Clang clang = Clang.Instance;

        public static readonly LlvmObjDump llvm_objdump = LlvmObjDump.Instance;

        public static readonly LlvmTableGen llvm_tblgen = LlvmTableGen.Instance;

        public static readonly LlvmReadObj llvm_readobj = LlvmReadObj.Instance;

        public static readonly LlvmAs llvm_as = LlvmAs.Instance;

        public sealed class Llc : Tool<Llc>
        {
            public Llc()
                : base(N.llc)
            {

            }
        }

        public sealed class LlvmMc : Tool<LlvmMc>
        {
            public LlvmMc()
                : base(N.llvm_mc)
            {

            }
        }

        public sealed class Clang : Tool<Clang>
        {
            public Clang()
                : base(N.clang)
            {

            }
        }

        public sealed class LlvmObjDump : Tool<LlvmObjDump>
        {
            public LlvmObjDump()
                : base(N.llvm_objdump)
            {

            }
        }

        public sealed class LlvmConfig : Tool<LlvmConfig>
        {
            public LlvmConfig()
                : base(N.llvm_config)
            {

            }
        }

        public sealed class LlvmReadObj : Tool<LlvmReadObj>
        {
            public LlvmReadObj()
                : base(N.llvm_readobj)
            {

            }
        }

        public sealed class LlvmAs : Tool<LlvmAs>
        {
            public LlvmAs()
                : base(N.llvm_as)
            {

            }
        }

        public sealed class LlvmTableGen : Tool<LlvmTableGen>
        {
            public LlvmTableGen()
                : base(N.llvm_tblgen)
            {

            }
        }
    }
}