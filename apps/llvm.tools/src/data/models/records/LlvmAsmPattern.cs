//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmPattern
    {
        public const string TableId = "llvm.asm.patterns";

        public const byte FieldCount = 9;

        public uint Seq;

        public ushort AsmId;

        public bit CGOnly;

        public bit Pseudo;

        public Identifier Instruction;

        public AsmMnemonic Mnemonic;

        public AsmVariationCode VarCode;

        public TextBlock FormatPattern;

        public TextBlock SourcePattern;

        public static LlvmAsmPattern Empty => default;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,6,8,8,24,16,12,42,1};
    }
}