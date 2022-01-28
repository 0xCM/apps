//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public class AsmSigs : AppService<AsmSigs>
    {
        const NumericKind Closure = UnsignedInts;

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmSigOp operand<T>(AsmSigOpKind kind, T value, NativeSizeCode size = NativeSizeCode.Unknown)
            where T : unmanaged
                => new AsmSigOp(kind, core.bw8(value), size);

        public Outcome Parse(string src, out AsmSig dst)
            => AsmSigParser.parse(src, out dst);

        public Outcome<AsmForm> BuildForm(in AsmSigExpr sigexpr, in CharBlock36 ocexpr)
        {
            var result = Outcome<AsmForm>.Empty;
            result = OpCodes.Parse(ocexpr, out var opcode);
            if(result)
            {
                var expect = text.trim(text.despace(ocexpr.Format()));
                var actual = opcode.Format();
                if(expect != actual)
                {
                    result = (false, string.Format("'{0}' != '{1}'", actual, expect));
                    return result;
                }
            }
            else
                return result;

            result = Parse(sigexpr.Format(), out var sig);
            if(result.Fail)
            {
                result = (false,string.Format("Sig parse failure:{0}", sigexpr.Format()));
                return result;
            }

            return new AsmForm(identify(new AsmFormExpr(sigexpr, ocexpr)).Text, sig, opcode);
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