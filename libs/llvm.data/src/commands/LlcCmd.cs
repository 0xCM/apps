//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Tools;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static LlcCmd Command(this Llc tool, FS.FilePath src, FS.FilePath dst)
        {
            var cmd = new LlcCmd();
            cmd.Source = src;
            cmd.Target = dst;
            return cmd;
        }
    }

    [Cmd(ToolNames.llc), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlcCmd : IToolFlowCmd<LlcCmd,Llc>
    {
        [CmdArg("<src>")]
        public FS.FilePath Source;

        [CmdArg("-o {0}")]
        public FS.FilePath Target;

        [CmdArg("--filetype={0}")]
        public string FileType;

        [CmdArg("--target-abi={0}")]
        public string TargetAbi;

        [CmdArg("--mtriple={0}")]
        public string Triple;

        [CmdArg("--x86-asm-syntax={0}")]
        public string X86AsmSyntax;

        [CmdFlag("--verify-machineinstrs")]
        public bit VerifyMachineInstructions;

        [CmdFlag("--asm-verbose")]
        public bit AsmVerbose;

        [CmdArg("{0}")]
        public string OptimizationLevel;

        [CmdFlag("--incremental-linker-compatible")]
        public bit IncrementalLinkerCompatible;

        [CmdArg("--mattr={0}")]
        public string Mattr;

        public Llc Tool
            => Tools.llc;

        FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Source
            => Source;

        FS.FilePath IFlowCmd<FS.FilePath, FS.FilePath>.Target
            => Target;
    }
}