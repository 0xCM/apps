//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmPattern
    {
        public const string TableId = "llvm.asm.patterns";

        public const byte FieldCount = 7;

        public uint Key;

        public bit IsCodeGenOnly;

        public bit IsPseudo;

        public AsciBlock32 Instruction;

        public AsmMnemonic Mnemonic;

        public AsmVariationCode Variation;

        public AsciBlock64 ExprFormat;

        public static LlvmAsmPattern Empty => default;
    }
}