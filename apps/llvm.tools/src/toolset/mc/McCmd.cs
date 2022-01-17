//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

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
        public string Cpu;

        [CmdFlag("--incremental-linker-compatible")]
        public bit IncrementalLinkerCompatible;

        [CmdArg("--x86-asm-syntax={0}")]
        public string X86AsmSyntax;

        [CmdArg("--output-asm-variant={0}", -1)]
        public sbyte OutputAsmVariant;

        [CmdFlag("--print-imm-hex")]
        public bit PrintImmHex;

        [CmdFlag("--masm-integers")]
        public bit MasmIntegers;

        [CmdFlag("--masm-hexfloats")]
        public bit MasmHexFloats;

        [CmdArg("--x86-align-branch-boundary={0}", -1)]
        public int X86AlignBranchBoundary;

        [CmdFlag(" --x86-branches-within-32B-boundaries")]
        public bit X86BranchesWithin32bBoundaries;

        [MethodImpl(Inline)]
        public McCmd()
        {
            Source = FS.FilePath.Empty;
            Target = FS.FilePath.Empty;
            Assemble = 1;
            FileType = @string.Empty;
            TargetAbi = @string.Empty;
            Triple = "x86_64-pc-windows-msvc";
            Cpu = "cascadelake";
            X86AsmSyntax = "intel";
            IncrementalLinkerCompatible = 1;
            OutputAsmVariant = 1;
            PrintImmHex = true;
            MasmIntegers = true;
            MasmHexFloats = true;
            X86AlignBranchBoundary = 32;
            X86BranchesWithin32bBoundaries = false;
        }

        IActor IFileFlowCmd.Actor
            => Tools.llvm_mc;

        FS.FilePath IFileFlowCmd.Source
            => Source;

        FS.FilePath IFileFlowCmd.Target
            => Target;

        public static McCmd Default => new();
    }
}