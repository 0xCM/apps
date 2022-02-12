//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using K = AsmSigTokenKind;

    partial class AsmSigs
    {
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

        public static Index<AsmForm> terminate2(in AsmForm src)
        {
            var forms = list<AsmForm>();
            var sig = new AsmSig(src.Mnemonic);
            if(nonterminal(src.Sig, out var j, out var termcount))
            {
                for(var i=z8; i<src.OpCount; i++)
                {
                    if(i==j)
                    {
                        if(termcount == 2)
                        {
                            split(src.Sig, out var a, out var b);
                            forms.AddRange(terminate2(AsmForm.define(a, src.OpCode)));
                            forms.AddRange(terminate2(AsmForm.define(b, src.OpCode)));
                        }
                        else if(termcount == 3)
                        {
                            split(src.Sig, out var a, out var b, out var c);
                            forms.AddRange(terminate2(AsmForm.define(a, src.OpCode)));
                            forms.AddRange(terminate2(AsmForm.define(b, src.OpCode)));
                            forms.AddRange(terminate2(AsmForm.define(c, src.OpCode)));
                        }
                        else
                            Errors.Throw("Bad");
                    }
                    else
                        sig.With(i,src.Sig[i]);

                }
                forms.Add(AsmForm.define(sig, src.OpCode));
            }
            else
                forms.Add(src);

            return forms.ToArray();
        }

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
    }
}