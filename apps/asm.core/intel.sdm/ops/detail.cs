//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct SdmOps
    {
        [Op]
        public static Outcome detail(TextLine src, out SdmOpCodeDetail dst)
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
            DataParser.block(skip(cells,i++).Trim(), out dst.OpCodeText);
            AsmParser.parse(skip(cells,i++), out dst.OpCodeValue);

            ref readonly var sigsrc = ref skip(cells,i++);
            if(sigsrc.Length == 0)
                dst.SigText = EmptyString;
            else
                dst.SigText = sigsrc;
            DataParser.block(skip(cells, i++), out dst.EncXRef);
            DataParser.block(skip(cells, i++), out dst.Mode64);
            DataParser.block(skip(cells, i++), out dst.Mode32);
            DataParser.block(skip(cells, i++), out dst.Mode64x32);
            DataParser.block(skip(cells, i++), out dst.CpuIdExpr);
            DataParser.block(skip(cells, i++), out dst.Description);
            return result;
        }
    }
}