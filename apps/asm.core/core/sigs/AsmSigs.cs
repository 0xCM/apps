//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    [ApiHost]
    public class AsmSigs
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static AsmForm form(in AsmSig sig, in AsmOpCode oc)
        {

            return default;
        }

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
                dst.Append(text.replace(text.replace(op.Text, Chars.Colon, Chars.x), Chars.Amp, Chars.a));
            }

            return dst.Emit();
        }
    }
}