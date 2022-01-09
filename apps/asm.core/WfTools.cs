//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using LLN = LlvmToolNames;

    public readonly struct WfTools
    {
        public static readonly Llc llc = Llc.Instance;

        public static readonly LlvmMc llvm_mc = LlvmMc.Instance;

        public static readonly LlvmConfig llvm_config = LlvmConfig.Instance;

        public static readonly Clang clang = Clang.Instance;

        public static readonly LlvmObjDump llvm_objdump = LlvmObjDump.Instance;

        public static readonly LlvmTableGen llvm_tblgen = LlvmTableGen.Instance;

        public static readonly LlvmReadObj llvm_readobj = LlvmReadObj.Instance;

        public static readonly LlvmDis llvm_dis = LlvmDis.Instance;

        public static readonly LlvmAs llvm_as = LlvmAs.Instance;

        public static readonly LlvmLld llvm_lld = LlvmLld.Instance;

        public abstract class LlvmTool<T> : Tool<T>
            where T : LlvmTool<T>, new()
        {

            protected LlvmTool(string name)
                : base(name)
            {

            }
        }

        public sealed class Llc : LlvmTool<Llc>
        {
            public Llc()
                : base(LLN.llc)
            {

            }
        }

        public sealed class LlvmMc : LlvmTool<LlvmMc>
        {
            public LlvmMc()
                : base(LLN.llvm_mc)
            {

            }
        }

        public sealed class Clang : LlvmTool<Clang>
        {
            public Clang()
                : base(LLN.clang)
            {

            }
        }

        public sealed class LlvmObjDump : LlvmTool<LlvmObjDump>
        {
            public LlvmObjDump()
                : base(LLN.llvm_objdump)
            {

            }
        }

        public sealed class LlvmConfig : LlvmTool<LlvmConfig>
        {
            public LlvmConfig()
                : base(LLN.llvm_config)
            {

            }
        }

        public sealed class LlvmReadObj : LlvmTool<LlvmReadObj>
        {
            public LlvmReadObj()
                : base(LLN.llvm_readobj)
            {

            }
        }

        public sealed class LlvmAs : LlvmTool<LlvmAs>
        {
            public LlvmAs()
                : base(LLN.llvm_as)
            {

            }
        }

        public sealed class LlvmTableGen : LlvmTool<LlvmTableGen>
        {
            public LlvmTableGen()
                : base(LLN.llvm_tblgen)
            {

            }
        }

        public sealed class LlvmDis : LlvmTool<LlvmDis>
        {
            public LlvmDis()
                : base(LLN.llvm_dis)
            {

            }
        }

        public sealed class LlvmLld : LlvmTool<LlvmLld>
        {
            public LlvmLld()
                : base(LLN.llvm_lld)
            {

            }
        }

        public sealed class LlvmNm : LlvmTool<LlvmNm>
        {
            public LlvmNm()
                : base(LLN.llvm_nm)
            {

            }
        }
    }
}