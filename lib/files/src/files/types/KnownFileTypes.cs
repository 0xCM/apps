//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class KnownFileTypes
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

        public sealed class Asm : FileType<Asm,FileKind>
        {
            public Asm()
                : base(FileKind.Asm, FileKind.Asm.Ext())
            {

            }
        }

        public sealed class AsmSyntax : FileType<AsmSyntax,FileKind>
        {
            public AsmSyntax()
                : base(FileKind.AsmSyntax, FileKind.AsmSyntax.Ext())
            {

            }
        }

        public sealed class AsmSyntaxLog : FileType<AsmSyntaxLog,FileKind>
        {
            public AsmSyntaxLog()
                : base(FileKind.AsmSyntaxLog, FileKind.AsmSyntaxLog.Ext())
            {

            }
        }

        public sealed class Bat : FileType<Bat,FileKind>
        {
            public Bat()
                : base(FileKind.Bat, FileKind.Bat.Ext())
            {

            }
        }

        public sealed class Bc : FileType<Bc,FileKind>
        {
            public Bc()
                : base(FileKind.Bc, FileKind.Bc.Ext())
            {

            }
        }

        public sealed class Bin : FileType<Bin,FileKind>
        {
            public Bin()
                : base(FileKind.Bin, FileKind.Bin.Ext())
            {

            }
        }

        public sealed class C : FileType<C,FileKind>
        {
            public C()
                : base(FileKind.C, FileKind.C.Ext())
            {

            }
        }

        public sealed class Cpp : FileType<Cpp,FileKind>
        {
            public Cpp()
                : base(FileKind.Cpp, FileKind.Cpp.Ext())
            {

            }
        }

        public sealed class Cs : FileType<Cs,FileKind>
        {
            public Cs()
                : base(FileKind.Cs, FileKind.Cs.Ext())
            {

            }
        }

        public sealed class Csv : FileType<Csv,FileKind>
        {
            public Csv()
                : base(FileKind.Csv, FileKind.Csv.Ext())
            {

            }
        }

        public sealed class Cmd : FileType<Cmd,FileKind>
        {
            public Cmd()
                : base(FileKind.Cmd, FileKind.Cmd.Ext())
            {

            }
        }

        public sealed class Dll : FileType<Dll,FileKind>
        {
            public Dll()
                : base(FileKind.Dll, FileKind.Dll.Ext())
            {

            }
        }

        public sealed class EncodingAsm : FileType<EncodingAsm,FileKind>
        {
            public EncodingAsm()
                : base(FileKind.EncodingAsm, FileKind.EncodingAsm.Ext())
            {

            }
        }

        public sealed class Exe : FileType<Exe,FileKind>
        {
            public Exe()
                : base(FileKind.Exe, FileKind.Exe.Ext())
            {

            }
        }

        public sealed class Header : FileType<Header,FileKind>
        {
            public Header()
                : base(FileKind.H, FileKind.H.Ext())
            {

            }
        }

        public sealed class Hex : FileType<Hex,FileKind>
        {
            public Hex()
                : base(FileKind.Hex, FileKind.Hex.Ext())
            {

            }
        }

        public sealed class Lib : FileType<Lib,FileKind>
        {
            public Lib()
                : base(FileKind.Lib, FileKind.Lib.Ext())
            {

            }
        }

        public sealed class LlAsm : FileType<LlAsm,FileKind>
        {
            public LlAsm()
                : base(FileKind.LlAsm, FileKind.LlAsm.Ext())
            {

            }
        }

        public sealed class Llir : FileType<Llir,FileKind>
        {
            public Llir()
                : base(FileKind.Llir, FileKind.Llir.Ext())
            {

            }
        }

        public sealed class Log : FileType<Log,FileKind>
        {
            public Log()
                : base(FileKind.Log, FileKind.Log.Ext())
            {

            }
        }

        public sealed class McAsm : FileType<McAsm,FileKind>
        {
            public McAsm()
                : base(FileKind.McAsm, FileKind.McAsm.Ext())
            {

            }
        }

        public sealed class Obj : FileType<Obj,FileKind>
        {
            public Obj()
                : base(FileKind.Obj, FileKind.Obj.Ext())
            {

            }
        }

        public sealed class Sym : FileType<Sym,FileKind>
        {
            public Sym()
                : base(FileKind.Sym, FileKind.Sym.Ext())
            {

            }
        }
    }
}