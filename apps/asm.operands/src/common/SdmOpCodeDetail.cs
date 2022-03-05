//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId), Blittable]
    public struct SdmOpCodeDetail : IRecord<SdmOpCodeDetail>, IComparable<SdmOpCodeDetail>
    {
        public const string TableId = "sdm.opcodes.details";

        public const byte FieldCount = 10;

        public uint OpCodeKey;

        public AsmMnemonic Mnemonic;

        public CharBlock36 OpCode;

        public CharBlock64 Sig;

        public CharBlock8 EncXRef;

        public CharBlock8 Mode64;

        public CharBlock8 Mode32;

        public CharBlock8 Mode64x32;

        public CharBlock16 CpuId;

        public CharBlock254 Description;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{
                12,16,36,64,
                10,10,10,10,
                16,254};

        public int CompareTo(SdmOpCodeDetail src)
            => Sig.String.CompareTo(src.Sig.String, NoCase);
    }
}