//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using Asm;

    [Record(TableId)]
    public struct LlvmInstAlias : IComparable<LlvmInstAlias>
    {
        public const string TableId = "llvm.inst.alias";

        public const byte FieldCount = 4;

        public Identifier InstName;

        public AsmMnemonic Mnemonic;

        public TextBlock AsmString;

        public TextBlock Syntax;

        public int CompareTo(LlvmInstAlias src)
            => InstName.CompareTo(src.InstName);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{24,16,48,1};
    }
}