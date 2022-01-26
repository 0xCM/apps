//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        public static Identifier identify(in AsmFormExpr src)
        {
            var dst = text.buffer();
            ref readonly var sig = ref src.Sig;
            dst.Append(sig.Mnemonic.Format(MnemonicCase.Lowercase));
            var ops = sig.Operands();
            var count = ops.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var op = ref skip(ops,i);
                dst.Append(Chars.Underscore);
                dst.Append(text.replace(op.Text, Chars.Colon, Chars.x));
            }

            return dst.Emit();
        }
    }
}