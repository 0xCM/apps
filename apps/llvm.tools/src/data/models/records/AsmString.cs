//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;
    using static Root;

    public readonly struct AsmString
    {
        const string RenderPattern = "{0,-24} | {1,-16} | {2,-54} | {3}";

        public readonly Identifier InstName;

        public readonly AsmMnemonic Mnemonic;

        public readonly TextBlock FormatPattern;

        public readonly TextBlock SourcePattern;

        public AsmString(Identifier name, AsmMnemonic mnemonic, string pattern, string raw)
        {
            InstName = name;
            Mnemonic = mnemonic;
            FormatPattern = pattern;
            SourcePattern = raw;
        }

        public string Format()
            => string.Format(RenderPattern, InstName, Mnemonic, FormatPattern, SourcePattern);

        public override string ToString()
            => Format();

        public static AsmString Empty => new AsmString(Identifier.Empty, AsmMnemonic.Empty, EmptyString, EmptyString);
    }

}