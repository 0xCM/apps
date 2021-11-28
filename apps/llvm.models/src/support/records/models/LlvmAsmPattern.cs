//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmPattern
    {
        public const string TableId = "llvm.asm.expressions.patterns";

        public uint Key;

        public AsciBlock32 Instruction;

        public AsciBlock32 Mnemonic;

        public bit IsCodeGenOnly;

        public bit IsPseudo;

        public AsciBlock64 ExprFormat;

        public static LlvmAsmPattern Empty => default;
    }
}