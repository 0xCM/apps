//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    [Record(TableId)]
    public struct LlvmInstDef : IComparable<LlvmInstDef>
    {
        public const string TableId = "llvm.asm.instdef";

        public const byte FieldCount = 9;

        public ushort AsmId;

        public bit CgOnly;

        public bit Pseudo;

        public Identifier InstName;

        public AsmMnemonic Mnemonic;

        public AsmVariationCode VarCode;

        public string FormatPattern;

        public string InOperandList;

        public string OutOperandList;

        [MethodImpl(Inline)]
        public int CompareTo(LlvmInstDef src)
            => AsmId.CompareTo(src.AsmId);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,6,6,24,16,12,54,64,1};
    }
}