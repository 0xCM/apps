//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    public partial class XedDomain
    {

    }

    [ApiHost]
    public class Tools : ITools
    {
        public static ITools Service => new Tools();

        [MethodImpl(Inline)]
        public static ref readonly T tool<T>()
            where T : Tool<T>, new()
                => ref Tool<T>.Instance;

        public static ref readonly Llc llc => ref Llc.Instance;

        public static ref readonly LlvmMc llvm_mc => ref LlvmMc.Instance;

        public static ref readonly LlvmConfig llvm_config => ref LlvmConfig.Instance;

        public static ref readonly Clang clang => ref Clang.Instance;

        public static ref readonly LlvmObjDump llvm_objdump => ref LlvmObjDump.Instance;

        public static ref readonly LlvmTableGen llvm_tblgen => ref LlvmTableGen.Instance;

        public static ref readonly LlvmReadObj llvm_readobj => ref LlvmReadObj.Instance;

        public static ref readonly LlvmDis llvm_dis => ref LlvmDis.Instance;

        public static ref readonly LlvmAs llvm_as => ref LlvmAs.Instance;

        public static ref readonly LlvmLld llvm_lld => ref LlvmLld.Instance;

        public static ref readonly ZTool ztool => ref ZTool.Instance;

        public static ref readonly Xed xed => ref Xed.Instance;

        public static ref readonly BdDisasm bddisasm => ref BdDisasm.Instance;

        public static ref readonly Msvs msvs => ref Msvs.Instance;

        public sealed class ZTool : Tool<ZTool>
        {
            public ZTool()
                : base("ZTool")
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Llc : Tool<Llc>
        {
            public Llc()
                : base(N.llc)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmMc : Tool<LlvmMc>
        {
            public LlvmMc()
                : base(N.llvm_mc)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Clang : Tool<Clang>
        {
            public Clang()
                : base(N.clang)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmObjDump : Tool<LlvmObjDump>
        {
            public LlvmObjDump()
                : base(N.llvm_objdump)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmConfig : Tool<LlvmConfig>
        {
            public LlvmConfig()
                : base(N.llvm_config)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmReadObj : Tool<LlvmReadObj>
        {
            public LlvmReadObj()
                : base(N.llvm_readobj)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmAs : Tool<LlvmAs>
        {
            public LlvmAs()
                : base(N.llvm_as)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmTableGen : Tool<LlvmTableGen>
        {
            public LlvmTableGen()
                : base(N.llvm_tblgen)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmDis : Tool<LlvmDis>
        {
            public LlvmDis()
                : base(N.llvm_dis)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmLld : Tool<LlvmLld>
        {
            public LlvmLld()
                : base(N.llvm_lld)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmNm : Tool<LlvmNm>
        {
            public LlvmNm()
                : base(N.llvm_nm)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Xed : Tool<Xed>
        {
            public Xed()
                : base(N.xed)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class BdDisasm : Tool<BdDisasm>
        {
            public BdDisasm()
                : base(N.bddisasm)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Msvs : Tool<Msvs>
        {
            public Msvs()
                : base(N.msvs)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }
    }
}