//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using Asm;

    using static Root;

    [Record(TableId)]
    public struct AsmString
    {
        public const string TableId = "llvm.asm.strings";

        public const byte FieldCount = 4;

        const string RenderPattern = "{0,-24} | {1,-16} | {2,-54} | {3}";

        public Identifier InstName;

        public AsmMnemonic Mnemonic;

        public TextBlock FormatPattern;

        public TextBlock SourceData;

        public AsmString(Identifier name, AsmMnemonic mnemonic, string pattern, string raw)
        {
            InstName = name;
            Mnemonic = mnemonic;
            FormatPattern = pattern;
            SourceData = raw;
        }

        public string Format()
            => string.Format(RenderPattern, InstName, Mnemonic, FormatPattern, SourceData);

        public override string ToString()
            => Format();

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{32,16,46,1};

        public static AsmString Empty => new AsmString(Identifier.Empty, AsmMnemonic.Empty, EmptyString, EmptyString);
    }
}