//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using Asm;

    [Record(TableId)]
    public struct LlvmInstPattern : IComparable<LlvmInstPattern>
    {
        public const string TableId = "llvm.inst.pattern";

        public const byte FieldCount = 5;

        public ushort AsmId;

        public Identifier InstName;

        public AsmMnemonic Mnemonic;

        public TextBlock FormatPattern;

        public TextBlock SourceData;

        public int CompareTo(LlvmInstPattern src)
            => AsmId.CompareTo(src.AsmId);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,16,48,1};
    }
}