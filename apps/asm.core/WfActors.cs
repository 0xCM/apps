//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using LLN = ToolNames;

    public readonly struct WfActors
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

        public static readonly ZTool ztool = ZTool.Instance;

        public static readonly Xed xed = Xed.Instance;

        public sealed class ZTool : WfToolActor<ZTool>
        {
            public ZTool()
                : base(nameof(ZTool))
            {

            }
        }

        public sealed class Llc : WfToolActor<Llc>
        {
            public Llc()
                : base(LLN.llc)
            {

            }
        }

        public sealed class LlvmMc : WfToolActor<LlvmMc>
        {
            public LlvmMc()
                : base(LLN.llvm_mc)
            {

            }
        }

        public sealed class Clang : WfToolActor<Clang>
        {
            public Clang()
                : base(LLN.clang)
            {

            }
        }

        public sealed class LlvmObjDump : WfToolActor<LlvmObjDump>
        {
            public LlvmObjDump()
                : base(LLN.llvm_objdump)
            {

            }
        }

        public sealed class LlvmConfig : WfToolActor<LlvmConfig>
        {
            public LlvmConfig()
                : base(LLN.llvm_config)
            {

            }
        }

        public sealed class LlvmReadObj : WfToolActor<LlvmReadObj>
        {
            public LlvmReadObj()
                : base(LLN.llvm_readobj)
            {

            }
        }

        public sealed class LlvmAs : WfToolActor<LlvmAs>
        {
            public LlvmAs()
                : base(LLN.llvm_as)
            {

            }
        }

        public sealed class LlvmTableGen : WfToolActor<LlvmTableGen>
        {
            public LlvmTableGen()
                : base(LLN.llvm_tblgen)
            {

            }
        }

        public sealed class LlvmDis : WfToolActor<LlvmDis>
        {
            public LlvmDis()
                : base(LLN.llvm_dis)
            {

            }
        }

        public sealed class LlvmLld : WfToolActor<LlvmLld>
        {
            public LlvmLld()
                : base(LLN.llvm_lld)
            {

            }
        }

        public sealed class LlvmNm : WfToolActor<LlvmNm>
        {
            public LlvmNm()
                : base(LLN.llvm_nm)
            {

            }
        }

        public sealed class Xed : WfToolActor<Xed>
        {
            public Xed()
                : base("xed")
            {

            }
        }
    }
}