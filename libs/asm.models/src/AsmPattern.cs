//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using W = AsmColWidths;

    [Record(TableId)]
    public struct AsmPattern : IComparable<AsmPattern>
    {
        public const string TableId = "llvm.asm.strings";

        [Render(W.AsmId)]
        public Identifier InstName;

        [Render(W.Mnemonic)]
        public AsmMnemonic Mnemonic;

        [Render(W.FormatPattern)]
        public TextBlock FormatPattern;

        [Render(1)]
        public TextBlock SourceData;

        public AsmPattern(Identifier name, AsmMnemonic mnemonic, string pattern, string raw)
        {
            InstName = name;
            Mnemonic = mnemonic;
            FormatPattern = pattern;
            SourceData = raw;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(SourceData.Text);
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(AsmPattern src)
        {
            var result = Mnemonic.CompareTo(src.Mnemonic);
            if(result == 0)
                result = InstName.CompareTo(src.InstName);

            return result;
        }

        public static AsmPattern Empty => new AsmPattern(Identifier.Empty, AsmMnemonic.Empty, EmptyString, EmptyString);
    }
}