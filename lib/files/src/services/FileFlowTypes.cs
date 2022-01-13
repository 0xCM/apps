//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static Tools;
    using static FileTypes;
    using static core;

    using FT = FileTypes;

    public readonly struct FileFlowTypes
    {
        public static FileFlowType define(Identifier actor, FileKind src, FileKind dst)
            => new FileFlowType(actor,src,dst);

        public static Index<IFileFlowType> discover(Assembly[] src)
        {
            var types = src.Types().Tagged<FileFlowTypeAttribute>().Concrete();
            var count = types.Length;
            var dst = alloc<IFileFlowType>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                seek(dst,i) = (IFileFlowType)Activator.CreateInstance(type);
            }
            return dst;
        }

        public static string format(IFileFlowType flow)
            => string.Format("{0}:*.{1} -> *.{2}", flow.Actor, flow.SourceExt, flow.TargetExt);

        /// <summary>
        /// *.asm -> *.mc.asm
        /// </summary>
        public class AsmToMcAsm : FileFlowType<AsmToMcAsm,LlvmMc,FT.Asm,McAsm>
        {
            public AsmToMcAsm()
                : base(llvm_mc, FT.Asm.Instance, McAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.ll -> *ll.asm
        /// </summary>
        public class LlToAsm : FileFlowType<LlToAsm,Llc,Llir,FT.Asm>
        {
            public LlToAsm()
                : base(llc, Llir.Instance, FT.Asm.Instance)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.bc
        /// </summary>
        public class LlToBc : FileFlowType<LlToBc,LlvmAs,Llir,Bc>
        {
            public LlToBc()
                : base(llvm_as, Llir.Instance, Bc.Instance)
            {

            }
        }

        /// <summary>
        /// *.ll -> *.obj
        /// </summary>
        public class LlToObj : FileFlowType<LlToObj,Llc,Llir,Obj>
        {
            public LlToObj()
                : base(llc, Llir.Instance, Obj.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToExe : FileFlowType<ObjToExe,LlvmLld,Obj,Exe>
        {
            public ObjToExe()
                : base(llvm_lld, Obj.Instance, Exe.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.exe
        /// </summary>
        public class ObjToObjAsm : FileFlowType<ObjToObjAsm,LlvmObjDump,Obj,ObjAsm>
        {
            public ObjToObjAsm()
                : base(llvm_objdump, Obj.Instance, ObjAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class ObjToHexDat : FileFlowType<ObjToHexDat,ZTool,Obj,HexDat>
        {
            public ObjToHexDat()
                : base(ztool, Obj.Instance, HexDat.Instance)
            {

            }
        }

        /// <summary>
        /// *.obj -> *.hex.dat
        /// </summary>
        public class OToHexDat : FileFlowType<OToHexDat,ZTool,O,HexDat>
        {
            public OToHexDat()
                : base(ztool, O.Instance, HexDat.Instance)
            {

            }
        }

        /// <summary>
        /// *.bc -> *.ll.bc
        /// </summary>
        public class BcToLlBc : FileFlowType<BcToLlBc,LlvmDis,Llir,Bc>
        {
            public BcToLlBc()
                : base(llvm_dis, Llir.Instance, Bc.Instance)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.encoding.asm
        /// </summary>
        public class LlAsmToAsmEncoding : FileFlowType<LlAsmToAsmEncoding,LlvmMc,FT.Asm,EncodingAsm>
        {
            public LlAsmToAsmEncoding ()
                : base(llvm_mc, FT.Asm.Instance, EncodingAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *ll.asm -> *.mc.asm
        /// </summary>
        public class LlasmToMcAsm : FileFlowType<LlasmToMcAsm,LlvmMc,FT.Asm,McAsm>
        {
            public LlasmToMcAsm()
                : base(llvm_mc, FT.Asm.Instance, McAsm.Instance)
            {

            }
        }


        /// <summary>
        /// *.encoding.asm -> *.syn.asm
        /// </summary>
        public class AsmEncodingToSynAsm : FileFlowType<AsmEncodingToSynAsm,LlvmMc,EncodingAsm,AsmSyntax>
        {
            public AsmEncodingToSynAsm()
                : base(llvm_mc, EncodingAsm.Instance, AsmSyntax.Instance)
            {

            }
        }

        /// <summary>
        /// *.encoding.asm -> *.syn.asm.log
        /// </summary>
        public class AsmEncodingToSynLog : FileFlowType<AsmEncodingToSynLog, LlvmMc, EncodingAsm, AsmSyntaxLog>
        {
            public AsmEncodingToSynLog()
                : base(llvm_mc, EncodingAsm.Instance, AsmSyntaxLog.Instance)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.encoding.asm
        /// </summary>
        public class AsmToMcEncoding : FileFlowType<AsmToMcEncoding,LlvmMc,FT.Asm,EncodingAsm>
        {
            public AsmToMcEncoding()
                : base(llvm_mc, asm, EncodingAsm.Instance)
            {

            }
        }

        /// <summary>
        /// *.asm -> *.encoding.asm
        /// </summary>
        public class ObjToXedDisasm : FileFlowType<ObjToXedDisasm,Xed,Obj,XedRawDisasm>
        {
            public ObjToXedDisasm()
                : base(xed, obj, xed_raw)
            {

            }
        }

        sealed class EmptyFlow : IFileFlowType
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