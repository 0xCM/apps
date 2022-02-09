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
                if(modifier(op,out var t, out var m))
                    buffer.AppendFormat("{0}_{1}", t, m);
                else
                    buffer.Append(op.Format());
            }
            return buffer.Emit().Replace("lock", "@lock");
        }
    }
}