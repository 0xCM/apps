//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static Tools;
    using static core;

    using FK = FileKind;

    public readonly struct FileFlowTypes
    {
        public static FileFlowType define(Identifier actor, FileKind src, FileKind dst)
            => new FileFlowType(actor,src,dst);

        public abstract class FileFlowType<F,A> : FileFlowType<F,A,FileKind>, IFileFlowType
            where F : FileFlowType<F,A>,new()
            where A : IActor
        {
            protected FileFlowType(A actor, FileKind src, FileKind dst)
                : base(actor,src,dst)
            {

            }

            public FK SourceKind => Source;

            public FK TargetKind => Target;
        }

        /// <summary>
        /// *.asm -> *.mc.asm
        /// </summary>
        public class AsmToMcAsm : FileFlowType<AsmToMcAsm,LlvmMc>
        {
            public AsmToMcAsm()
                : base(llvm_mc, FK.Asm, FK.McAsm)
            {

            }
        }

        /// <summary>
        /// *.ll -> *ll.asm
        /// </summary>
        public class LlToAsm : FileFlowType<LlToAsm,Llc>
        {
            public LlToAsm()
                : base(llc, FK.Llir, FK.LlAsm)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.bc
        /// </summary>
        public class LlToBc : FileFlowType<LlToBc,LlvmAs>
        {
            public LlToBc()
                : base(llvm_as, FK.Llir, FK.Bc)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.obj
        /// </summary>
        public class LlToObj : FileFlowType<LlToObj,Llc>
        {
            public LlToObj()
                : base(llc, FK.Llir, FK.Obj)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToExe : FileFlowType<ObjToExe,LlvmLld>
        {
            public ObjToExe()
                : base(llvm_lld, FK.Obj, FK.Exe)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToObjAsm : FileFlowType<ObjToObjAsm,LlvmObjDump>
        {
            public ObjToObjAsm()
                : base(llvm_objdump, FK.Obj, FK.ObjAsm)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class ObjToHexDat : FileFlowType<ObjToHexDat,ZTool>
        {
            public ObjToHexDat()
                : base(ztool, FK.Obj, FK.HexDat)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class OToHexDat : FileFlowType<OToHexDat,ZTool>
        {
            public OToHexDat()
                : base(ztool, FK.O, FK.HexDat)
            {

            }
        }

        /// <summary>
        /// *.bc -> *.ll.bc
        /// </summary>
        public class BcToLlBc : FileFlowType<BcToLlBc,LlvmDis>
        {
            public BcToLlBc()
                : base(llvm_dis, FK.Bc, FK.LlBc)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.encoding.asm
        /// </summary>
        public class LlAsmToAsmEncoding : FileFlowType<LlAsmToAsmEncoding,LlvmMc>
        {
            public LlAsmToAsmEncoding()
                : base(llvm_mc, FK.Asm, FK.EncAsm)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.mc.asm
        /// </summary>
        public class LlasmToMcAsm : FileFlowType<LlasmToMcAsm,LlvmMc>
        {
            public LlasmToMcAsm()
                : base(llvm_mc, FK.Asm, FK.McAsm)
            {

            }
        }


        /// <summary>
        /// *.enc.asm -> *.syn.asm
        /// </summary>
        public class EncAsmToSynAsm : FileFlowType<EncAsmToSynAsm,LlvmMc>
        {
            public EncAsmToSynAsm()
                : base(llvm_mc, FK.EncAsm, FK.SynAsm)
            {

            }
        }

        /// <summary>
        /// *.enc.asm -> *.syn.asm.log
        /// </summary>
        public class EncAsmToSynLog : FileFlowType<EncAsmToSynLog, LlvmMc>
        {
            public EncAsmToSynLog()
                : base(llvm_mc, FK.EncAsm, FK.SynAsmLog)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.enc.asm
        /// </summary>
        public class AsmToEncAsm : FileFlowType<AsmToEncAsm,LlvmMc>
        {
            public AsmToEncAsm()
                : base(llvm_mc, FK.Asm, FK.EncAsm)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.xed.disam.txt
        /// </summary>
        public class ObjToXedDisasm : FileFlowType<ObjToXedDisasm,Xed>
        {
            public ObjToXedDisasm()
                : base(xed, FileKind.Obj, FileKind.XedRawDisasm)
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
        }

        sealed class EmptyActor : IActor
        {
            public static EmptyActor Instance = new();

            public Identifier Name => Identifier.Empty;
        }
    }
}