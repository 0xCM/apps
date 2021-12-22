//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmTools;
    using static KnownFileTypes;

    public readonly struct LlvmDataFlows
    {
        /// <summary>
        /// llc:asm -> mc.asm
        /// </summary>
        public class AsmToMcAsm : DataFlow<AsmToMcAsm,Llc,Asm,McAsm>
        {
            public AsmToMcAsm()
                : base(llc, asm, mcasm)
            {

            }
        }

        /// <summary>
        /// llc:asm -> encoding.asm
        /// </summary>
        public class AsmToMcEncoding : DataFlow<AsmToMcEncoding,LlvmMc,Asm,EncodingAsm>
        {
            public AsmToMcEncoding()
                : base(llvm_mc, asm, encasm)
            {

            }
        }

        /// <summary>
        /// llvm-as:ll -> bc
        /// </summary>
        public class LlToBc : DataFlow<LlToBc,LlvmAs,Llir,Bc>
        {
            public LlToBc()
                : base(llvm_as,ll,bc)
            {

            }
        }

        /// <summary>
        /// llc:ll -> obj
        /// </summary>
        public class LlToObj : DataFlow<LlToObj,Llc,Llir,Obj>
        {
            public LlToObj()
                : base(llc,ll,obj)
            {

            }
        }
    }
}