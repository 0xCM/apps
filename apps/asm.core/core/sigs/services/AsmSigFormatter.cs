//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmSigFormatter
    {
        AsmSigDatasets Datasets;

        public AsmSigFormatter()
        {
            Datasets = AsmSigDatasets.load();
        }

        public static string format(in AsmSigExpr src)
        {
            var storage = CharBlock64.Null;
            var dst = storage.Data;
            var i=0u;
            text.copy(src.Mnemonic.Format(MnemonicCase.Lowercase), ref i, dst);
            var count = src.OperandCount;

            if(count != 0)
                seek(dst,i++) = Chars.Space;

            AsmSigExpr.operands(src, ref i, dst);
            return storage.Format();
        }

        public static string format(AsmSigRuleExpr src)
        {
            var dst = text.buffer();
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            var count = src.Operands.Count;
            for(var i=0; i<count; i++)
            {
                if(i == 0)
                    dst.Append(Chars.Space);
                else
                    dst.Append(", ");

                dst.Append(src.Operands[i].ToString());
            }
            return dst.Emit();
        }

        public static string format(in AsmSig src)
        {
            var dst = text.buffer();
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            var count = src.OpCount;
            for(byte i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(", ");
                else
                    dst.Append(Chars.Space);

                dst.Append(expression(src[i]).Format());
            }
            return dst.Emit();
        }

        public string Format(in AsmSig src)
            => format(src);

        public static AsmSigOpExpr expression(AsmSigOp src)
        {
            if(_Datasets.TokenExpressions.Find(src.Id, out var xpr))
            {
                if(src.Modifier != 0)
                {
                    if(_Datasets.Modifers.MapKind(src.Modifier, out var mod))
                        return string.Format("{0} {1}", xpr, mod.Expr);
                    else
                        return RP.Error;
                }
                else
                    return xpr;
            }
            else
                return RP.Error;
        }

        static AsmSigFormatter()
        {
            _Datasets = AsmSigDatasets.load();
        }

        static AsmSigDatasets _Datasets;
    }
}