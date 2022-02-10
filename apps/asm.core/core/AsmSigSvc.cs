//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public partial class AsmSigSvc : AppService<AsmSigSvc>
    {
        const NumericKind Closure = UnsignedInts;

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        IntelSdm Sdm => Service(Wf.IntelSdm);


        public Outcome Parse(string src, out AsmSig dst)
            => AsmSigs.parse(src, out dst);

        public Outcome Terminals(out Index<AsmSig> dst)
        {
            var result = Outcome.Success;
            var terms = Sdm.LoadSymbolicSigs();
            var count = terms.Count;
            dst = alloc<AsmSig>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var term = ref terms[i];
                ref readonly var target = ref term.Target;
                result = Parse(target.Format(), out dst[i]);
                if(result.Fail)
                    break;
            }
            return result;
        }

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

            result = AsmSigs.parse(sigexpr.Format(), out var sig);
            if(result.Fail)
            {
                result = (false,string.Format("Sig parse failure:{0}", sigexpr.Format()));
                return result;
            }

            return new AsmForm(AsmForm.identify(new AsmFormExpr(sigexpr, ocexpr)).Text, sig, opcode);
        }
    }
}