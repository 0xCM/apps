//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmSigTokens;

    partial class AsmSigs
    {
        public static ReadOnlySpan<AsmSigOpKind> opkinds()
            => Datasets.Kinds;

        public static Index<AsmForm> terminate(in AsmForm src)
        {
            var forms = list<AsmForm>();
            var sig = new AsmSig(src.Mnemonic);
            for(var i=z8; i<src.OpCount; i++)
            {
                var ops = terminate(src.Operands[i]);
                var count = ops.Count;

                if(count == 1)
                    sig = sig.With(i, ops.First);
                else
                {
                    for(var j=0; j<count; j++)
                        forms.AddRange(terminate(AsmForm.define(src.Sig.With(i, ops[j]), src.OpCode)));
                }
            }

            if(sig.OpCount == src.OpCount)
                forms.Add(AsmForm.define(sig, src.OpCode));
            return forms.ToArray();
        }

        public static AsmSigOp operand<K>(K src)
            where K : unmanaged
                => new AsmSigOp(Datasets.Kind(typeof(K)), u8(src));

        public static Index<AsmSigOp> terminate(in AsmSigOp src)
        {
            var dst = list<AsmSigOp>();
            var fmt = src.Format();
            var i = text.index(fmt, Chars.FSlash);
            if(i > 0)
            {
                var left = text.trim(text.left(fmt,i));
                var right = text.trim(text.split(fmt, Chars.FSlash));
                for(var j=0; j<right.Length; j++)
                {
                    var result = operand(skip(right,j), out var op);
                    if(result)
                        dst.Add(op);
                }
            }
            else
                dst.Add(src);

            return dst.ToArray();
        }

        public static bool modified(in AsmSigOp src)
            => text.contains(src.Format(), Chars.LBrace);

        public static bool modified(in AsmSig src)
        {
            var count = src.OpCount;
            for(var i=0; i<count; i++)
            {
                if(modified(src[i]))
                    return true;
            }
            return false;
        }
    }
}