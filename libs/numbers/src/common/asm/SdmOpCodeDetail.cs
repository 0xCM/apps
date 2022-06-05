//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct SdmOpCodeDetail : IRecord<SdmOpCodeDetail>, IComparable<SdmOpCodeDetail>
    {
        const string TableId = "sdm.opcodes.details";

        public const byte FieldCount = 11;

        public static Outcome parse(TextLine src, out SdmOpCodeDetail dst)
        {
            var result = Outcome.Success;
            var cells = src.Split(Chars.Pipe);
            var count = cells.Length;
            dst = default;
            if(count != SdmOpCodeDetail.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(SdmOpCodeDetail.FieldCount, count));

            var i=0;

            result = DataParser.parse(skip(cells,i++), out dst.OpCodeKey);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.OpCodeKey), skip(cells,i-1)));

            dst.Mnemonic = skip(cells, i++).ToUpperInvariant();
            DataParser.block(skip(cells,i++).Trim(), out dst.OpCodeExpr);
            AsmOcValue.parse(skip(cells,i++), out dst.OpCodeValue);

            ref readonly var sigsrc = ref skip(cells,i++);
            if(sigsrc.Length == 0)
                dst.AsmSig = EmptyString;
            else
                dst.AsmSig = sigsrc;
            DataParser.block(skip(cells, i++), out dst.EncXRef);
            DataParser.block(skip(cells, i++), out dst.Mode64);
            DataParser.block(skip(cells, i++), out dst.Mode32);
            DataParser.block(skip(cells, i++), out dst.Mode64x32);
            DataParser.block(skip(cells, i++), out dst.CpuIdExpr);
            DataParser.block(skip(cells, i++), out dst.Description);
            return result;
        }

        [Render(12)]
        public uint OpCodeKey;

        [Render(12)]
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