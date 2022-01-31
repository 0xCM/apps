//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial struct SdmOps
    {
        public static Outcome row(TextLine src, out SdmSigOpCode dst)
        {
            const byte FieldCount = SdmSigOpCode.FieldCount;

            var result = Outcome.Success;
            var cells = src.Split(Chars.Pipe);
            var count = cells.Length;
            dst = default;
            if(count != FieldCount)
                return (false, Tables.FieldCountMismatch.Format(FieldCount, count));

            var i=0;
            DataParser.parse(skip(cells,i++), out dst.Seq);
            DataParser.parse(skip(cells,i++), out dst.Identity);
            AsmSigParser.expression(skip(cells,i++), out dst.Sig);
            dst.OpCode = skip(cells,i++).Trim();
            dst.Op0 = skip(cells,i++).Trim();
            dst.Op1 = skip(cells,i++).Trim();
            dst.Op2 = skip(cells,i++).Trim();
            dst.Op3 = skip(cells,i++).Trim();
            return result;
        }

        [Op]
        public static Outcome row(TextLine src, out SdmOpCodeDetail dst)
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

            dst.Mnemonic = asm.mnemonic(skip(cells, i++));
            DataParser.block(skip(cells, i++).Trim(), out dst.OpCode);
            DataParser.block(skip(cells, i++), out dst.Sig);
            DataParser.block(skip(cells, i++), out dst.EncXRef);
            DataParser.block(skip(cells, i++), out dst.Mode64);
            DataParser.block(skip(cells, i++), out dst.LegacyMode);
            DataParser.block(skip(cells, i++), out dst.Mode64x32);
            DataParser.block(skip(cells, i++), out dst.CpuId);
            DataParser.block(skip(cells, i++), out dst.Description);
            return result;
        }
    }
}