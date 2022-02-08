//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
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
                if(op.Modifier(out var t, out var m))
                    buffer.AppendFormat("{0}_{1}", t, m);
                else
                    buffer.Append(op.Format());
            }
            return buffer.Emit().Replace("lock", "@lock");
        }
    }
}