//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfFileTypes
    {
        public static Asm asm = Asm.Instance;

        public static AsmSyntax asmsyn = AsmSyntax.Instance;

        public static AsmSyntaxLog asmsynlog = AsmSyntaxLog.Instance;

        public static Bat bat = Bat.Instance;

        public static Bc bc = Bc.Instance;

        public static C c = C.Instance;

        public static Cmd cmd = Cmd.Instance;

        public static Cs cs = Cs.Instance;

        public static Cpp cpp = Cpp.Instance;

        public static Csv csv = Csv.Instance;

        public static Dll dll = Dll.Instance;

        public static EncodingAsm encasm = EncodingAsm.Instance;

        public static Header h = Header.Instance;

        public static Lib lib = Lib.Instance;

        public static Llir ll = Llir.Instance;

        public static LlAsm llasm = LlAsm.Instance;

        public static Log log = Log.Instance;

        public static McAsm mcasm = McAsm.Instance;

        public static Obj obj = Obj.Instance;

        public static Sym sym = Sym.Instance;

        public static XedSummaryDisasm xed_summary = XedSummaryDisasm.Instance;

        public static XedSemtanicDisasm xed_semantic = XedSemtanicDisasm.Instance;

        public static XedRawDisasm xed_raw = XedRawDisasm.Instance;

        public interface IWfFileType : IFileType<WfFileKind>
        {

        }

        public abstract class WfFileType<T> : FileType<T, WfFileKind>, IWfFileType
            where T : WfFileType<T>,new()
        {
            protected WfFileType(WfFileKind kind)
                :base(kind, kind.Ext())

            {

            }
        }

        public sealed class Asm : WfFileType<Asm>
        {
            public Asm()
                : base(WfFileKind.Asm)
            {

            }
        }

        public sealed class AsmSyntax : WfFileType<AsmSyntax>
        {
            public AsmSyntax()
                : base(WfFileKind.AsmSyntax)
            {

            }
        }

        public sealed class AsmSyntaxLog : WfFileType<AsmSyntaxLog>
        {
            public AsmSyntaxLog()
                : base(WfFileKind.AsmSyntaxLog)
            {

            }
        }

        public sealed class Bat : WfFileType<Bat>
        {
            public Bat()
                : base(WfFileKind.Bat)
            {

            }
        }

        public sealed class Bc : WfFileType<Bc>
        {
            public Bc()
                : base(WfFileKind.Bc)
            {

            }
        }

        public sealed class Bin : WfFileType<Bin>
        {
            public Bin()
                : base(WfFileKind.Bin)
            {

            }
        }

        public sealed class C : WfFileType<C>
        {
            public C()
                : base(WfFileKind.C)
            {

            }
        }

        public sealed class Cpp : WfFileType<Cpp>
        {
            public Cpp()
                : base(WfFileKind.Cpp)
            {

            }
        }

        public sealed class Cs : WfFileType<Cs>
        {
            public Cs()
                : base(WfFileKind.Cs)
            {

            }
        }

        public sealed class Csv : WfFileType<Csv>
        {
            public Csv()
                : base(WfFileKind.Csv)
            {

            }
        }

        public sealed class Cmd : WfFileType<Cmd>
        {
            public Cmd()
                : base(WfFileKind.Cmd)
            {

            }
        }

        public sealed class Dll : WfFileType<Dll>
        {
            public Dll()
                : base(WfFileKind.Dll)
            {

            }
        }

        public sealed class EncodingAsm : WfFileType<EncodingAsm>
        {
            public EncodingAsm()
                : base(WfFileKind.EncodingAsm)
            {

            }
        }

        public sealed class Exe : WfFileType<Exe>
        {
            public Exe()
                : base(WfFileKind.Exe)
            {

            }
        }

        public sealed class Header : WfFileType<Header>
        {
            public Header()
                : base(WfFileKind.H)
            {

            }
        }

        public sealed class Hex : WfFileType<Hex>
        {
            public Hex()
                : base(WfFileKind.Hex)
            {

            }
        }

        public sealed class HexDat : WfFileType<HexDat>
        {
            public HexDat()
                : base(WfFileKind.HexDat)
            {

            }
        }

        public sealed class Lib : WfFileType<Lib>
        {
            public Lib()
                : base(WfFileKind.Lib)
            {

            }
        }

        public sealed class LlAsm : WfFileType<LlAsm>
        {
            public LlAsm()
                : base(WfFileKind.LlAsm)
            {

            }
        }

        public sealed class Llir : WfFileType<Llir>
        {
            public Llir()
                : base(WfFileKind.Llir)
            {

            }
        }

        public sealed class Log : WfFileType<Log>
        {
            public Log()
                : base(WfFileKind.Log)
            {

            }
        }

        public sealed class McAsm : WfFileType<McAsm>
        {
            public McAsm()
                : base(WfFileKind.McAsm)
            {

            }
        }

        public sealed class O : WfFileType<O>
        {
            public O()
                : base(WfFileKind.O)
            {

            }
        }

        public sealed class Obj : WfFileType<Obj>
        {
            public Obj()
                : base(WfFileKind.Obj)
            {

            }
        }

        public sealed class ObjAsm : WfFileType<ObjAsm>
        {
            public ObjAsm()
                : base(WfFileKind.ObjAsm)
            {

            }
        }

        public sealed class Sym : WfFileType<Sym>
        {
            public Sym()
                : base(WfFileKind.Sym)
            {

            }
        }

        public sealed class XedRawDisasm : WfFileType<XedRawDisasm>
        {
            public XedRawDisasm()
                : base(WfFileKind.XedRawDisasm)
            {

            }
        }

        public sealed class XedSemtanicDisasm : WfFileType<XedSemtanicDisasm>
        {
            public XedSemtanicDisasm()
                : base(WfFileKind.XedSemanticDisasm)
            {

            }
        }

        public sealed class XedSummaryDisasm : WfFileType<XedSummaryDisasm>
        {
            public XedSummaryDisasm()
                : base(WfFileKind.XedSummaryDisasm)
            {

            }
        }
    }
}