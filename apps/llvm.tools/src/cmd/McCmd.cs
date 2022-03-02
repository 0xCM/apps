//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Cmd(ToolNames.llvm_mc), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct McCmd : IFileFlowCmd<McCmd>
    {
        public McCmd()
        {

        }

        [CmdArg("<src>")]
        public FS.FilePath Source = FS.FilePath.Empty;

        [CmdArg("-o {0}")]
        public FS.FilePath Target = FS.FilePath.Empty;

        [CmdFlag("--assemble")]
        public bit Assemble = 0;

        [CmdArg("--filetype={0}")]
        public string FileType = EmptyString;

        [CmdArg("--target-abi={0}")]
        public string TargetAbi = EmptyString;

        [CmdArg("--triple={0}")]
        public string Triple = EmptyString;

        [CmdArg("--mcpu={0}")]
        public string MCpu = EmptyString;

        [CmdFlag("--incremental-linker-compatible")]
        public bit IncrementalLinkerCompatible = 0;

        [CmdArg("--x86-asm-syntax={0}")]
        public string X86AsmSyntax = EmptyString;

        [CmdArg("--output-asm-variant={0}", -1)]
        public int OutputAsmVariant = -1;

        [CmdFlag("--print-imm-hex")]
        public bit PrintImmHex = 0;

        [CmdFlag("--masm-integers")]
        public bit MasmIntegers = 0;

        [CmdFlag("--masm-hexfloats")]
        public bit MasmHexFloats = 0;

        [CmdArg("--x86-align-branch-boundary={0}", -1)]
        public int X86AlignBranchBoundary = -1;

        [CmdFlag("--x86-branches-within-32B-boundaries")]
        public bit X86BranchesWithin32bBoundaries = 0;

        [CmdFlag("--show-encoding")]
        public bit ShowEncoding = 0;

        [CmdFlag("--fdebug-compilation-dir={0}")]
        public FS.FolderPath DebugCompliationDir = FS.FolderPath.Empty;

        IActor IFileFlowCmd.Actor
            => Tools.llvm_mc;

        FS.FilePath IFileFlowCmd.Source
            => Source;

        FS.FilePath IFileFlowCmd.Target
            => Target;

        public static McCmd Empty => default;
    }
}