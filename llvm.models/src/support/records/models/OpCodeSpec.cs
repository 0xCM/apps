//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;

    using static LlvmNames;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct OpCodeSpec : IRecord<OpCodeSpec>, IComparable<OpCodeSpec>
    {
        public const string TableId = TableNames.OpCodes;

        public const byte FieldCount = 5;

        public ushort Index;

        public AsmId Id;

        public CharBlock48 Mnemonic;

        public Hex64 OpCodeValue;

        public CharBlock24 OpCodeBytes;

        public int CompareTo(OpCodeSpec src)
            => Id.CompareTo(src.Id);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,32,48,16,24};
    }
}