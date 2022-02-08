//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Record(TableId)]
    public struct SibBitfieldRow
    {
        public const string TableId = "sib.bits";

        public const byte FieldCount = 5;

        public uint2 scale;

        public uint3 index;

        public uint3 @base;

        public Hex8 hex;

        public CharBlock10 bitstring;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{5,5,5,3,10};
    }


    [Record(TableId)]
    public struct SibRegCodes
    {
        public const string TableId = "sib.regcodes";

        public const byte FieldCount = 5;

        public text7 Base;

        public text7 Index;

        public uint2 Scale;

        public Hex8 Hex;

        public CharBlock10 Bits;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{5,5,5,3,10};
    }
}