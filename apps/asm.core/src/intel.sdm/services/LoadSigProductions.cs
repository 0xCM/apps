//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmSigProduction> LoadSigProductions()
        {
            var result = Outcome.Success;
            var path = SdmPaths.SigProductions();
            var lines = path.ReadLines();
            var count = lines.Count;
            var dst = alloc<AsmSigProduction>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                if(empty(line))
                    continue;

                result = Parse(line, out seek(dst,i));
                if(result.Fail)
                    break;
            }

            if(result)
                return dst;
            else
            {
                Error(result);
                return sys.empty<AsmSigProduction>();
            }
        }

        Outcome Parse(string src, out AsmSigProduction dst)
        {
            var result = Outcome.Success;
            dst = AsmSigProduction.Empty;
            result = RuleParser.production(src, out IProduction prod);
            if(result)
            {
                var sig = AsmSigs.expression(prod.Source.Format());
                if(result)
                {
                    result = Parse(prod.Target.Format(), out AsmSigRuleExpr expr);
                    if(result)
                        dst = new AsmSigProduction(sig,expr);
                }
            }

            return result;
        }

        Outcome Parse(string src, out AsmSigRuleExpr dst)
        {
            var result = Outcome.Success;
            dst = AsmSigRuleExpr.Empty;
            var sig = AsmSigs.expression(src);
            if(result)
            {
                var ops = sig.Operands();
                var count = (byte)ops.Length;
                dst = new AsmSigRuleExpr(sig.Mnemonic, count);
                for(byte i=0; i<count; i++)
                {
                    ref readonly var op = ref skip(ops,i);
                    result = RuleParser.expression(op.Text, out IRuleExpr expr);

                    if(result)
                        dst.WithOperand(i, expr);
                    else
                        break;
                }
            }
            return result;
        }
    }
}