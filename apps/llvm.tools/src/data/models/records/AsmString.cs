//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    public readonly struct AsmString
    {
        public readonly ushort AsmId;

        public readonly AsmMnemonic Mnemonic;

        public readonly TextBlock FormatPattern;

        public readonly TextBlock SourcePattern;

        public AsmString(ushort id, AsmMnemonic mnemonic, string src, string fmt)
        {
            AsmId = id;
            Mnemonic = mnemonic;
            FormatPattern = fmt;
            SourcePattern = src;
        }
    }

}