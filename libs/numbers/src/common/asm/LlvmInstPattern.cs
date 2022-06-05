//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using W = AsmColWidths;

    [Record(TableId)]
    public struct LlvmInstPattern : IComparable<LlvmInstPattern>
    {
        const string TableId = "llvm.inst.pattern";

        public const byte FieldCount = 5;

        [Render(W.Seq)]
        public ushort AsmId;

        [Render(W.AsmId)]
        public Identifier InstName;

        [Render(W.Mnemonic)]
        public AsmMnemonic Mnemonic;

        [Render(W.FormatPattern)]
        public TextBlock FormatPattern;

        [Render(1)]
        public TextBlock SourceData;

        public int CompareTo(LlvmInstPattern src)
            => AsmId.CompareTo(src.AsmId);
    }
}