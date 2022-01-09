//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WfTools;
    using static WfFileTypes;

    using FT = WfFileTypes;

    public readonly struct WfDataFlows
    {
        /// <summary>
        /// *.ll -> *ll.asm
        /// </summary>
        public class LlToAsm : DataFlow<LlToAsm,Llc,Llir,FT.Asm>
        {
            public LlToAsm()
                : base(llc, Llir.Instance, FT.Asm.Instance)
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

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToExe : DataFlow<ObjToExe,LlvmLld,Obj,Exe>
        {
            public ObjToExe()
                : base(llvm_lld, Obj.Instance, Exe.Instance)
            {

            }

        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToObjAsm : DataFlow<ObjToObjAsm,LlvmObjDump,Obj,ObjAsm>
        {
            public ObjToObjAsm()
                : base(llvm_objdump, Obj.Instance, ObjAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.bc -> *.ll.bc
        /// </summary>
        public class BcToLlBc : DataFlow<BcToLlBc,LlvmDis,Llir,Bc>
        {
            public BcToLlBc()
                : base(llvm_dis, Llir.Instance, Bc.Instance)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.encoding.asm
        /// </summary>
        public class LlAsmToAsmEncoding : DataFlow<LlAsmToAsmEncoding,LlvmMc,FT.Asm,EncodingAsm>
        {
            public LlAsmToAsmEncoding ()
                : base(llvm_mc, FT.Asm.Instance, EncodingAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.mc.asm
        /// </summary>
        public class LlasmToMcAsm : DataFlow<LlasmToMcAsm,LlvmMc,FT.Asm,McAsm>
        {
            public LlasmToMcAsm()
                : base(llvm_mc, FT.Asm.Instance, McAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.mc.asm
        /// </summary>
        public class AsmToMcAsm : DataFlow<AsmToMcAsm,LlvmMc,FT.Asm,McAsm>
        {
            public AsmToMcAsm()
                : base(llvm_mc, FT.Asm.Instance, McAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.encoding.asm -> *.syn.asm
        /// </summary>
        public class AsmEncodingToSynAsm : DataFlow<AsmEncodingToSynAsm,LlvmMc,EncodingAsm,AsmSyntax>
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
        /// *.asm -> *.encoding.asm
        /// </summary>
        public class AsmToMcEncoding : DataFlow<AsmToMcEncoding,LlvmMc,FT.Asm,EncodingAsm>
        {
            public AsmToMcEncoding()
                : base(llvm_mc, FT.Asm.Instance, EncodingAsm.Instance)
            {

            }
        }
    }
}