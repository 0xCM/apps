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
        public string MCpu;

        [CmdFlag("--incremental-linker-compatible")]
        public bit IncrementalLinkerCompatible;

        [CmdArg("--x86-asm-syntax={0}")]
        public string X86AsmSyntax;

        [CmdArg("--output-asm-variant={0}", -1)]
        public int OutputAsmVariant;

        [CmdFlag("--print-imm-hex")]
        public bit PrintImmHex;

        [CmdFlag("--masm-integers")]
        public bit MasmIntegers;

        [CmdFlag("--masm-hexfloats")]
        public bit MasmHexFloats;

        [CmdArg("--x86-align-branch-boundary={0}", -1)]
        public int X86AlignBranchBoundary;

        [CmdFlag("--x86-branches-within-32B-boundaries")]
        public bit X86BranchesWithin32bBoundaries;

        [CmdFlag("--show-encoding")]
        public bit ShowEncoding;

        IActor IFileFlowCmd.Actor
            => Tools.llvm_mc;

        FS.FilePath IFileFlowCmd.Source
            => Source;

        FS.FilePath IFileFlowCmd.Target
            => Target;

        public static McCmd Default
        {
            get
            {
                var dst = new McCmd();
                dst.Source = FS.FilePath.Empty;
                dst.Target = FS.FilePath.Empty;
                dst.Assemble = 1;
                dst.FileType = EmptyString;
                dst.TargetAbi = EmptyString;
                dst.Triple = "x86_64-pc-windows-msvc";
                dst.MCpu = "cascadelake";
                dst.X86AsmSyntax = "intel";
                dst.IncrementalLinkerCompatible = 1;
                dst.OutputAsmVariant = 1;
                dst.PrintImmHex = true;
                dst.MasmIntegers = true;
                dst.MasmHexFloats = true;
                dst.X86AlignBranchBoundary = -1;
                dst.X86BranchesWithin32bBoundaries = false;
                dst.ShowEncoding = true;
                return dst;
            }
        }

        public static McCmd Empty
        {
            get
            {
                var dst = new McCmd();
                dst.Source = FS.FilePath.Empty;
                dst.Target = FS.FilePath.Empty;
                dst.FileType = EmptyString;
                dst.TargetAbi = EmptyString;
                dst.X86AlignBranchBoundary = -1;
                dst.OutputAsmVariant = -1;
                return dst;
            }
        }
    }
}