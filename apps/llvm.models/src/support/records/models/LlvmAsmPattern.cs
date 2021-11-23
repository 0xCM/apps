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

        public AsciBlock64 ExprFormat;

        public static ref LlvmAsmPattern define(uint key, in AsciBlock32 name, in AsciBlock32 mnemonic, in AsciBlock64 format, out LlvmAsmPattern dst)
        {
            dst.Key = key;
            dst.Instruction = name;
            dst.Mnemonic = mnemonic;
            dst.ExprFormat = format;
            return ref dst;
        }

        public static LlvmAsmPattern Empty => default;
    }
}