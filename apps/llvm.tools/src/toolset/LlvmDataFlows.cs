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
        /// *.asm -> *.mc.asm
        /// </summary>
        public class AsmToMcAsm : DataFlow<AsmToMcAsm,LlvmMc,Asm,McAsm>
        {
            public AsmToMcAsm()
                : base(llvm_mc, Asm.Instance, McAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.encoding.asm -> *.syn.asm
        /// </summary>
        public class AsmEncodingToSynAsm : DataFlow<AsmEncodingToSynAsm, LlvmMc, EncodingAsm, AsmSyntax>
        {
            public AsmEncodingToSynAsm()
                : base(llvm_mc, EncodingAsm.Instance, AsmSyntax.Instance)
            {

            }
        }

        /// <summary>
        /// *.encoding.asm -> *.syn.asm.log
        /// </summary>
        public class AsmEncodingToSynLog : DataFlow<AsmEncodingToSynLog, LlvmMc, EncodingAsm, AsmSyntaxLog>
        {
            public AsmEncodingToSynLog()
                : base(llvm_mc, EncodingAsm.Instance, AsmSyntaxLog.Instance)
            {

            }
        }

        /// <summary>
        /// llc:asm -> encoding.asm
        /// </summary>
        public class AsmToMcEncoding : DataFlow<AsmToMcEncoding,LlvmMc,Asm,EncodingAsm>
        {
            public AsmToMcEncoding()
                : base(llvm_mc, Asm.Instance, EncodingAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.bc
        /// </summary>
        public class LlToBc : DataFlow<LlToBc,LlvmAs,Llir,Bc>
        {
            public LlToBc()
                : base(llvm_as, Llir.Instance, Bc.Instance)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.obj
        /// </summary>
        public class LlToObj : DataFlow<LlToObj,Llc,Llir,Obj>
        {
            public LlToObj()
                : base(llc, Llir.Instance, Obj.Instance)
            {

            }
        }
    }
}