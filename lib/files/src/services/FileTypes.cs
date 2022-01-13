//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileTypes
    {
        public static FileType define(string name, params FS.FileExt[] ext)
            => new FileType(name, ext);

        public static FileType<K> define<K>(K kind, params FS.FileExt[] ext)
            where K : unmanaged
                => new FileType<K>(kind, ext);

        public static FS.FileExt ext(FileKind src)
            => FS.ext(format(src));

        public static string name(FileKind src)
            => Symbols.index<FileKind>()[src].Name.ToLower();

        [Op]
        public static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();

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

        public interface IWfFileType : IFileType<FileKind>
        {

        }

        public abstract class WfFileType<T> : FileType<T, FileKind>, IWfFileType
            where T : WfFileType<T>,new()
        {
            protected WfFileType(FileKind kind)
                :base(kind, kind.Ext())

            {

            }
        }

        public sealed class Asm : WfFileType<Asm>
        {
            public Asm()
                : base(FileKind.Asm)
            {

            }
        }

        public sealed class AsmSyntax : WfFileType<AsmSyntax>
        {
            public AsmSyntax()
                : base(FileKind.AsmSyntax)
            {

            }
        }

        public sealed class AsmSyntaxLog : WfFileType<AsmSyntaxLog>
        {
            public AsmSyntaxLog()
                : base(FileKind.AsmSyntaxLog)
            {

            }
        }

        public sealed class Bat : WfFileType<Bat>
        {
            public Bat()
                : base(FileKind.Bat)
            {

            }
        }

        public sealed class Bc : WfFileType<Bc>
        {
            public Bc()
                : base(FileKind.Bc)
            {

            }
        }

        public sealed class Bin : WfFileType<Bin>
        {
            public Bin()
                : base(FileKind.Bin)
            {

            }
        }

        public sealed class C : WfFileType<C>
        {
            public C()
                : base(FileKind.C)
            {

            }
        }

        public sealed class Cpp : WfFileType<Cpp>
        {
            public Cpp()
                : base(FileKind.Cpp)
            {

            }
        }

        public sealed class Cs : WfFileType<Cs>
        {
            public Cs()
                : base(FileKind.Cs)
            {

            }
        }

        public sealed class Csv : WfFileType<Csv>
        {
            public Csv()
                : base(FileKind.Csv)
            {

            }
        }

        public sealed class Cmd : WfFileType<Cmd>
        {
            public Cmd()
                : base(FileKind.Cmd)
            {

            }
        }

        public sealed class Dll : WfFileType<Dll>
        {
            public Dll()
                : base(FileKind.Dll)
            {

            }
        }

        public sealed class EncodingAsm : WfFileType<EncodingAsm>
        {
            public EncodingAsm()
                : base(FileKind.EncodingAsm)
            {

            }
        }

        public sealed class Exe : WfFileType<Exe>
        {
            public Exe()
                : base(FileKind.Exe)
            {

            }
        }

        public sealed class Header : WfFileType<Header>
        {
            public Header()
                : base(FileKind.H)
            {

            }
        }

        public sealed class Hex : WfFileType<Hex>
        {
            public Hex()
                : base(FileKind.Hex)
            {

            }
        }

        public sealed class HexDat : WfFileType<HexDat>
        {
            public HexDat()
                : base(FileKind.HexDat)
            {

            }
        }

        public sealed class Lib : WfFileType<Lib>
        {
            public Lib()
                : base(FileKind.Lib)
            {

            }
        }

        public sealed class LlAsm : WfFileType<LlAsm>
        {
            public LlAsm()
                : base(FileKind.LlAsm)
            {

            }
        }

        public sealed class Llir : WfFileType<Llir>
        {
            public Llir()
                : base(FileKind.Llir)
            {

            }
        }

        public sealed class Log : WfFileType<Log>
        {
            public Log()
                : base(FileKind.Log)
            {

            }
        }

        public sealed class McAsm : WfFileType<McAsm>
        {
            public McAsm()
                : base(FileKind.McAsm)
            {

            }
        }

        public sealed class O : WfFileType<O>
        {
            public O()
                : base(FileKind.O)
            {

            }
        }

        public sealed class Obj : WfFileType<Obj>
        {
            public Obj()
                : base(FileKind.Obj)
            {

            }
        }

        public sealed class ObjAsm : WfFileType<ObjAsm>
        {
            public ObjAsm()
                : base(FileKind.ObjAsm)
            {

            }
        }

        public sealed class Sym : WfFileType<Sym>
        {
            public Sym()
                : base(FileKind.Sym)
            {

            }
        }

        public sealed class XedRawDisasm : WfFileType<XedRawDisasm>
        {
            public XedRawDisasm()
                : base(FileKind.XedRawDisasm)
            {

            }
        }

        public sealed class XedSemtanicDisasm : WfFileType<XedSemtanicDisasm>
        {
            public XedSemtanicDisasm()
                : base(FileKind.XedSemanticDisasm)
            {

            }
        }

        public sealed class XedSummaryDisasm : WfFileType<XedSummaryDisasm>
        {
            public XedSummaryDisasm()
                : base(FileKind.XedSummaryDisasm)
            {

            }
        }

    }

    partial class XTend
    {
        public static FS.FileExt Ext(this FileKind src)
            => FileTypes.ext(src);

        public static FileType<FileKind> FileType(this FileKind src)
            => FileTypes.define(src, FileTypes.ext(src));

        public static string Name(this FileKind src)
            => FileTypes.name(src);
    }
}