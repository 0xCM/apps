//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId), Blittable]
    public struct SdmOpCodeDetail : IRecord<SdmOpCodeDetail>, IComparable<SdmOpCodeDetail>
    {
        public const string TableId = "sdm.opcodes.details";

        public const byte FieldCount = 10;

        public uint OpCodeKey;

        public CharBlock16 Mnemonic;

        public CharBlock48 OpCode;

        public CharBlock64 Sig;

        public CharBlock8 EncXRef;

        public CharBlock8 Mode64;

        public CharBlock8 LegacyMode;

        public CharBlock8 Mode64x32;

        public CharBlock16 CpuId;

        public CharBlock254 Description;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{
                12,16,48,64,
                10,10,10,10,
                16,
                254};

        public int CompareTo(SdmOpCodeDetail src)
            => Sig.String.CompareTo(src.Sig.String, NoCase);
    }
}