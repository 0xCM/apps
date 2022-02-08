//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public partial class AsmSigs : AppService<AsmSigs>
    {
        const NumericKind Closure = UnsignedInts;

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        static AsmSigOpExpr sigop(IRuleExpr src)
            => src.Format().Replace(":", "x").Replace("&", "a");

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

            result = AsmSigParser.parse(sigexpr.Format(), out var sig);
            if(result.Fail)
            {
                result = (false,string.Format("Sig parse failure:{0}", sigexpr.Format()));
                return result;
            }

            return new AsmForm(AsmForm.identify(new AsmFormExpr(sigexpr, ocexpr)).Text, sig, opcode);
        }
    }
}