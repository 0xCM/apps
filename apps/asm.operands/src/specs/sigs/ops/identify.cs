//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        static AsmSigOpExpr sigop(IRuleExpr src)
            => src.Format().Replace(":", "x").Replace("&", "a");

        public static bool OpMask(in AsmSig src, out AsmSigOp dst)
        {
            var result = false;
            var count = src.OpCount;
            dst = AsmSigOp.Empty;
            ref readonly var ops = ref src.Operands;
            for(var i=0; i<count; i++)
            {
                var op = ops[i];
                result = op.OpKind == AsmSigOpKind.OpMask;
                if(result)
                {
                    dst = op;
                    break;
                }
            }
            return result;
        }

        public static Identifier identify(in AsmSigOp src)
        {
            if(Datasets.TokenExpressions.Find(src.Id, out var xpr))
            {
                if(src.Modifier != 0)
                {
                    if(Datasets.Modifers.MapKind(src.Modifier, out var mod))

                        return string.Format("{0}_{1}", xpr, mod.Kind);
                    else
                        return RP.Error;
                }
                else
                    return xpr;
            }
            else
                return RP.Error;
        }

        public static Identifier identify(in AsmSig src)
        {
            var dst = text.buffer();
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            for(byte j=0; j<src.OpCount; j++)
            {
                dst.Append(Chars.Underscore);
                dst.Append(identify(src.Operands[j]));
            }

            return dst.Emit();
        }

        public static Identifier identify(AsmSigRuleExpr target)
        {
            var operands = target.Operands;
            var opcount = operands.Count;
            var buffer = text.buffer();
            buffer.Append(target.Mnemonic.Format(MnemonicCase.Lowercase));
            for(var j=0; j<opcount; j++)
            {
                buffer.Append(Chars.Underscore);

                var op = sigop(operands[j]);
                buffer.Append(op.Format());
            }
            return buffer.Emit().Replace("lock", "@lock");
        }
    }
}