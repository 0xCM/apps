//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmSigFormatter
    {
        AsmSigDatasets Datasets;

        public AsmSigFormatter()
        {
            Datasets = AsmSigDatasets.load();
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
                    if(_Datasets.Modifers.MakKind(src.Modifier, out var mod))
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