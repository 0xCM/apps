//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct SdmOpCodeDetail : IComparable<SdmOpCodeDetail>
    {
        const string TableId = "sdm.opcodes.details";

        public const byte FieldCount = 11;

        [Render(12)]
        public uint OpCodeKey;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(36)]
        public CharBlock36 OpCodeExpr;

        [Render(36)]
        public AsmOcValue OpCodeValue;

        [Render(64)]
        public CharBlock64 AsmSig;

        [Render(8)]
        public CharBlock8 EncXRef;

        [Render(8)]
        public CharBlock8 Mode64;

        [Render(8)]
        public CharBlock8 Mode32;

        [Render(12)]
        public CharBlock8 Mode64x32;

        [Render(16)]
        public CharBlock16 CpuIdExpr;

        [Render(254)]
        public CharBlock254 Description;

        public int CompareTo(SdmOpCodeDetail src)
        {
            var result = Mnemonic.CompareTo(src.Mnemonic);
            if(result == 0)
            {
                result = OpCodeValue.CompareTo(src.OpCodeValue);
                if(result == 0)
                    result = AsmSig.String.CompareTo(src.AsmSig.String, NoCase);
            }

            return result;
        }
    }
}