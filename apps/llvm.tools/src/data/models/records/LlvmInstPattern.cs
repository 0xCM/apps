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

        [Render(8)]
        public ushort AsmId;

        [Render(24)]
        public Identifier InstName;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(48)]
        public TextBlock FormatPattern;

        [Render(1)]
        public TextBlock SourceData;

        public int CompareTo(LlvmInstPattern src)
            => AsmId.CompareTo(src.AsmId);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,16,48,1};
    }
}