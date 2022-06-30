//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    [SymSource(api)]
    public enum FileKind : uint
    {
        None = 0,

        [Symbol(asm,"Formatted x86 assembly")]
        Asm,

        [Symbol(encasm, "An asm file that contains the encoding as comments")]
        EncAsm,

        [Symbol(synasm)]
        SynAsm,

        [Symbol(synasmlog)]
        SynAsmLog,

        [Symbol(bat, "A windows batch file")]
        Bat,

        [Symbol(bc, "An llvm-ir binary file")]
        Bc,

        [Symbol(bin, "A flat binary file")]
        Bin,

        [Symbol("bits", "A bitfield specification")]
        Bits,

        [Symbol(i, "A file generated by a pre-processor for a c translation unit")]
        Ci,

        [Symbol(ii, "A file generated by a pre-processor for a cpp translation unit")]
        Cii,

        [Symbol(cil, "Msil source text")]
        Cil,

        [Symbol(cmd, "A windows batch file")]
        Cmd,

        [Symbol(c, "A c source file")]
        C,

        [Symbol(config, "A text file with colon-delimited key-value lines")]
        Config,

        [Symbol(coffheaders, "A file containing a textual description of the headers in a COFF object file")]
        CoffHeaders,

        [Symbol(cpp, "A cpp source file")]
        Cpp,

        [Symbol(csv,"Delimited data rows")]
        Csv,

        [Symbol(cs, "A csharp source file")]
        Cs,

        [Symbol(csproj, "A CSharp project file")]
        CsProj,

        [Symbol(dmp, "A windows dump file")]
        Dmp,

        [Symbol(def)]
        Def,

        [Symbol(dll, "A dynamic library module")]
        Dll,

        [Symbol(exe, "A portable executable file")]
        Exe,

        [Symbol(h, "A C/C++ header file")]
        H,

        [Symbol(hex, "Text-formatted hex data")]
        Hex,

        [Symbol(hexdat)]
        HexDat,

        [Symbol(ildata, "MSIL organized in tabular format")]
        IlData,

        [Symbol(idx)]
        Idx,

        [Symbol(inc)]
        Inc,

        [Symbol(json, "Json data")]
        Json,

        [Symbol(lib, "A static library module")]
        Lib,

        [Symbol(list, "A simple eol-delimited text file")]
        List,

        [Symbol(llasm, "An asm file produced by llc")]
        LlAsm,

        [Symbol(llbc, "An llvm bitcode file produced by compilation of an *.ll file")]
        LlBc,

        [Symbol(ll, "An llvm-ir text file")]
        Llir,

        [Symbol(log,"Text-formatted log data")]
        Log,

        [Symbol(map,"A configuration file that correlates line-ranges and records/entities")]
        Map,

        [Symbol(mcasm, "An asm file produced by the llvm-mc tool")]
        McAsm,

        [Symbol(md, "A Mardown document")]
        Md,

        [Symbol(mlir)]
        Mlir,

        [Symbol(mir)]
        Mir,

        [Symbol(o, "A coff object file")]
        O,

        [Symbol(obi, "A textual description of acoff object file as produced by llvm-readobj")]
        Obi,

        [Symbol(obj, "A coff object file")]
        Obj,

        [Symbol(objasm, "An assembly file derived from an object file")]
        ObjAsm,

        [Symbol(objyaml)]
        ObjYaml,

        [Symbol(pdb, "A program database file")]
        Pdb,

        [Symbol(pcsv,"Text-formatted x86-encoded/executable data")]
        PCsv,

        [Symbol(s, "A file with an ugly asm syntax, also known as ATT syntax")]
        S,

        [Symbol(sh, "A bash shell script")]
        Sh,

        [Symbol(sql, "A sql script")]
        Sql,

        [Symbol(sym,"A symbol table as emitted by llvm-nm")]
        Sym,

        [Symbol(td, "An llvm table definition file")]
        Td,

        [Symbol(txt,"Text data")]
        Txt,

        [Symbol(xcsv,"Unprocessed x86-encoded data")]
        XCsv,

        [Symbol(xpack, "Text-formatted hex with base addresses")]
        XPack,

        [Symbol(xml, "Xml data")]
        Xml,

        [Symbol(yamltok)]
        YamlTok,

        [Symbol(xeddisasm_raw, "Xed disassembly information as emitted from the xed tool")]
        XedRawDisasm,

        [Symbol(xeddisasm_summary, "Xed disassembly tabular summary")]
        XedSummaryDisasm,

        [Symbol(xeddisasm_semantic, "Xed disassembly details with semantic interpretation")]
        XedSemanticDisasm,

        [Symbol(xeddisasm_detail, "Xed disassembly details in columnar format")]
        XedDisasmDetail,

        [Symbol(zip, "A zip archive file")]
        Zip,

        [Symbol(env, "An environment configuration file")]
        Env,

        [Symbol(help, "A plaintext tool help file")]
        Help,
    }
}