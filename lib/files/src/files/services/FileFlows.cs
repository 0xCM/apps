//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WfActors;
    using static FileTypes;

    using FT = FileTypes;

    public readonly struct FileFlows
    {
        public static string format(IFileFLow flow)
            => string.Format("{0}:*.{1} -> *.{2}", flow.Actor, flow.SourceExt, flow.TargetExt);

        public static IFileFLow flow(FileKind src, FileKind dst)
        {
            var flow = EmptyFlow.Instance;
            switch(src)
            {
                case FileKind.Asm:
                break;
                case FileKind.Bc:
                break;
                case FileKind.HexDat:
                break;
                case FileKind.Exe:
                break;
                case FileKind.Llir:
                break;
                case FileKind.LlAsm:
                break;
                case FileKind.McAsm:
                break;

                case FileKind.O:
                case FileKind.Obj:
                break;

                case FileKind.Sym:
                break;

            }

            return flow;
        }


        /// <summary>
        /// *.ll -> *ll.asm
        /// </summary>
        public class LlToAsm : WfFileFlow<LlToAsm,Llc,Llir,FT.Asm>
        {
            public LlToAsm()
                : base(llc, Llir.Instance, FT.Asm.Instance)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.bc
        /// </summary>
        public class LlToBc : WfFileFlow<LlToBc,LlvmAs,Llir,Bc>
        {
            public LlToBc()
                : base(llvm_as, Llir.Instance, Bc.Instance)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.obj
        /// </summary>
        public class LlToObj : WfFileFlow<LlToObj,Llc,Llir,Obj>
        {
            public LlToObj()
                : base(llc, Llir.Instance, Obj.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToExe : WfFileFlow<ObjToExe,LlvmLld,Obj,Exe>
        {
            public ObjToExe()
                : base(llvm_lld, Obj.Instance, Exe.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToObjAsm : WfFileFlow<ObjToObjAsm,LlvmObjDump,Obj,ObjAsm>
        {
            public ObjToObjAsm()
                : base(llvm_objdump, Obj.Instance, ObjAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class ObjToHexDat : WfFileFlow<ObjToHexDat,ZTool,Obj,HexDat>
        {
            public ObjToHexDat()
                : base(ztool, Obj.Instance, HexDat.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class OToHexDat : WfFileFlow<OToHexDat,ZTool,O,HexDat>
        {
            public OToHexDat()
                : base(ztool, O.Instance, HexDat.Instance)
            {

            }
        }

        /// <summary>
        /// *.bc -> *.ll.bc
        /// </summary>
        public class BcToLlBc : WfFileFlow<BcToLlBc,LlvmDis,Llir,Bc>
        {
            public BcToLlBc()
                : base(llvm_dis, Llir.Instance, Bc.Instance)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.encoding.asm
        /// </summary>
        public class LlAsmToAsmEncoding : WfFileFlow<LlAsmToAsmEncoding,LlvmMc,FT.Asm,EncodingAsm>
        {
            public LlAsmToAsmEncoding ()
                : base(llvm_mc, FT.Asm.Instance, EncodingAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.mc.asm
        /// </summary>
        public class LlasmToMcAsm : WfFileFlow<LlasmToMcAsm,LlvmMc,FT.Asm,McAsm>
        {
            public LlasmToMcAsm()
                : base(llvm_mc, FT.Asm.Instance, McAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.mc.asm
        /// </summary>
        public class AsmToMcAsm : WfFileFlow<AsmToMcAsm,LlvmMc,FT.Asm,McAsm>
        {
            public AsmToMcAsm()
                : base(llvm_mc, FT.Asm.Instance, McAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.encoding.asm -> *.syn.asm
        /// </summary>
        public class AsmEncodingToSynAsm : WfFileFlow<AsmEncodingToSynAsm,LlvmMc,EncodingAsm,AsmSyntax>
        {
            public AsmEncodingToSynAsm()
                : base(llvm_mc, EncodingAsm.Instance, AsmSyntax.Instance)
            {

            }
        }

        /// <summary>
        /// *.encoding.asm -> *.syn.asm.log
        /// </summary>
        public class AsmEncodingToSynLog : WfFileFlow<AsmEncodingToSynLog, LlvmMc, EncodingAsm, AsmSyntaxLog>
        {
            public AsmEncodingToSynLog()
                : base(llvm_mc, EncodingAsm.Instance, AsmSyntaxLog.Instance)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.encoding.asm
        /// </summary>
        public class AsmToMcEncoding : WfFileFlow<AsmToMcEncoding,LlvmMc,FT.Asm,EncodingAsm>
        {
            public AsmToMcEncoding()
                : base(llvm_mc, asm, EncodingAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.encoding.asm
        /// </summary>
        public class ObjToXedDisasm : WfFileFlow<ObjToXedDisasm,Xed,Obj,XedRawDisasm>
        {
            public ObjToXedDisasm()
                : base(xed, obj, xed_raw)
            {

            }
        }

        sealed class EmptyFlow : IFileFLow
        {
            public static EmptyFlow Instance = new();

            public FileKind SourceKind => FileKind.None;

            public FileKind TargetKind => throw new System.NotImplementedException();

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