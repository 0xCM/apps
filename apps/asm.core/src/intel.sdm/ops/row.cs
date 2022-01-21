//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static AsmSigs;

    partial struct SdmOps
    {
        [Parser]
        public static Outcome parse(string src, out AsmSigExpr dst)
        {
            var result = Outcome.Success;
            var sig = text.trim(src);
            var j = text.index(text.trim(sig), Chars.Space);
            var mnemonic = AsmMnemonic.Empty;
            dst = AsmSigExpr.Empty;
            if(j>0)
            {
                mnemonic = text.left(sig,j);
                var operands = text.right(sig,j);
                if(text.contains(sig, Chars.Comma))
                    dst = expression(mnemonic, text.trim(text.split(operands, Chars.Comma)));
                else
                    dst = expression(mnemonic, operands);
            }
            else
            {
                mnemonic = sig;
                dst = expression(mnemonic);
            }

            return result;
        }

        public static Outcome row(TextLine src, out SigOpCode dst)
        {
            const byte FieldCount = SigOpCode.FieldCount;

            var result = Outcome.Success;
            var cells = src.Split(Chars.Pipe);
            var count = cells.Length;
            dst = default;
            if(count != FieldCount)
                return (false, Tables.FieldCountMismatch.Format(FieldCount, count));

            var i=0;
            DataParser.parse(skip(cells,i++), out dst.Seq);
            parse(skip(cells,i++), out dst.Sig);
            dst.OpCode = asm.opcode(0u, skip(cells,i++).Trim());
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