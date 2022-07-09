//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Tools;

    using K = FileKind;

    public class FileFlows
    {
        /// <summary>
        /// *.asm -> *.mc.asm
        /// </summary>
        public class AsmToMcAsm : FileFlow<AsmToMcAsm,LlvmMc>
        {
            public AsmToMcAsm()
                : base(llvm_mc, K.Asm, K.McAsm)
            {

            }
        }

        /// <summary>
        /// *.ll -> *ll.asm
        /// </summary>
        public class LlToAsm : FileFlow<LlToAsm,Llc>
        {
            public LlToAsm()
                : base(llc, K.Llir, K.LlAsm)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.bc
        /// </summary>
        public class LlToBc : FileFlow<LlToBc,LlvmAs>
        {
            public LlToBc()
                : base(llvm_as, K.Llir, K.Bc)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.obj
        /// </summary>
        public class LlToObj : FileFlow<LlToObj,Llc>
        {
            public LlToObj()
                : base(llc, K.Llir, K.Obj)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToExe : FileFlow<ObjToExe,LlvmLld>
        {
            public ObjToExe()
                : base(llvm_lld, K.Obj, K.Exe)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToObjAsm : FileFlow<ObjToObjAsm,LlvmObjDump>
        {
            public ObjToObjAsm()
                : base(llvm_objdump, K.Obj, K.ObjAsm)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class ObjToHexDat : FileFlow<ObjToHexDat,ZTool>
        {
            public ObjToHexDat()
                : base(ztool, K.Obj, K.HexDat)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class OToHexDat : FileFlow<OToHexDat,ZTool>
        {
            public OToHexDat()
                : base(ztool, K.O, K.HexDat)
            {

            }
        }

        /// <summary>
        /// *.bc -> *.ll.bc
        /// </summary>
        public class BcToLlBc : FileFlow<BcToLlBc,LlvmDis>
        {
            public BcToLlBc()
                : base(llvm_dis, K.Bc, K.LlBc)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.encoding.asm
        /// </summary>
        public class LlAsmToAsmEncoding : FileFlow<LlAsmToAsmEncoding,LlvmMc>
        {
            public LlAsmToAsmEncoding()
                : base(llvm_mc, K.Asm, K.EncAsm)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.mc.asm
        /// </summary>
        public class LlasmToMcAsm : FileFlow<LlasmToMcAsm,LlvmMc>
        {
            public LlasmToMcAsm()
                : base(llvm_mc, K.Asm, K.McAsm)
            {

            }
        }


        /// <summary>
        /// *.enc.asm -> *.syn.asm
        /// </summary>
        public class EncAsmToSynAsm : FileFlow<EncAsmToSynAsm,LlvmMc>
        {
            public EncAsmToSynAsm()
                : base(llvm_mc, K.EncAsm, K.SynAsm)
            {

            }
        }

        /// <summary>
        /// *.enc.asm -> *.syn.asm.log
        /// </summary>
        public class EncAsmToSynLog : FileFlow<EncAsmToSynLog, LlvmMc>
        {
            public EncAsmToSynLog()
                : base(llvm_mc, K.EncAsm, K.SynAsmLog)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.enc.asm
        /// </summary>
        public class AsmToEncAsm : FileFlow<AsmToEncAsm,LlvmMc>
        {
            public AsmToEncAsm()
                : base(llvm_mc, K.Asm, K.EncAsm)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.xed.disam.txt
        /// </summary>
        public class ObjToXedDisasm : FileFlow<ObjToXedDisasm,Xed>
        {
            public ObjToXedDisasm()
                : base(xed, FileKind.Obj, FileKind.XedRawDisasm)
            {

            }
        }

        /// <summary>
        /// *.s -> *.asm
        /// </summary>
        public class SToAsm : FileFlow<SToAsm,LlvmMc>
        {
            public SToAsm()
                :base(llvm_mc, FileKind.S, FileKind.Asm)
            {

            }
        }

        sealed class EmptyFlow : IFileFlowType
        {
            public static EmptyFlow Instance = new();

            public FileKind SourceKind => FileKind.None;

            public FileKind TargetKind => FileKind.None;

            public IActor Actor => EmptyActor.Instance;

            public dynamic Source => SourceKind;

            public dynamic Target => TargetKind;

            public string Format() => EmptyString;
        }

        sealed class EmptyActor : IActor
        {
            public static EmptyActor Instance = new();

            public Name Name => asci64.Null;
        }
    }
}