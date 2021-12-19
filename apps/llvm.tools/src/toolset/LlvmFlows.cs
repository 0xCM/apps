//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmTools;
    using static KnownFileTypes;

    public readonly struct LlvmFlows
    {
        /// <summary>
        /// llc:asm -> mc.asm
        /// </summary>

        public class AsmToMcAsm : DataFlow<AsmToMcAsm,Llc,Asm,McAsm>
        {
            public AsmToMcAsm()
                : base(llc,asm,mcasm)
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