//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Cmd(ToolNames.llvm_mc), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct McCmd : IFileFlowCmd<McCmd>
    {
        [CmdArg("<src>")]
        public FS.FilePath Source;

        [CmdArg("-o {0}")]
        public FS.FilePath Target;

        [CmdFlag("--assemble")]
        public bit Assemble;

        [CmdArg("--filetype={0}")]
        public string FileType;

        [CmdArg("--target-abi={0}")]
        public string TargetAbi;

        [CmdArg("--triple={0}")]
        public string Triple;

        [CmdArg("--mcpu={0}")]
        public string MCpu;

        [CmdFlag("--incremental-linker-compatible")]
        public bit IncrementalLinkerCompatible;

        [CmdArg("--x86-asm-syntax={0}")]
        public string X86AsmSyntax;

        [CmdArg("--output-asm-variant={0}", -1)]
        public int OutputAsmVariant = -1;

        [CmdFlag("--print-imm-hex")]
        public bit PrintImmHex;

        [CmdFlag("--masm-integers")]
        public bit MasmIntegers;

        [CmdFlag("--masm-hexfloats")]
        public bit MasmHexFloats;

        [CmdArg("--x86-align-branch-boundary={0}", -1)]
        public int X86AlignBranchBoundary = -1;

        [CmdFlag("--x86-branches-within-32B-boundaries")]
        public bit X86BranchesWithin32bBoundaries;

        [CmdFlag("--show-encoding")]
        public bit ShowEncoding;

        [CmdFlag("--fdebug-compilation-dir={0}")]
        public FS.FolderPath DebugCompliationDir;

        IActor IFileFlowCmd.Actor
            => Tools.llvm_mc;

        FS.FilePath IFileFlowCmd.Source
            => Source;

        FS.FilePath IFileFlowCmd.Target
            => Target;

        public static McCmd Empty => default;
    }
}