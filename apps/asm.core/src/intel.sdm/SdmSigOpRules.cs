//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;
    using static Root;

    public class SdmSigOpRules : AppService<SdmSigOpRules>
    {
        Productions DecompRules;

        Productions OpMaskRules;

        IntelSdmPaths SdmPaths => Service(Wf.SdmPaths);

        public SdmSigOpRules()
        {

        }

        protected override void OnInit()
        {
            LoadRules();
        }

        void LoadRules()
        {
            DecompRules = Rules.productions(SdmPaths.SigDecompRules());
            OpMaskRules = Rules.productions(SdmPaths.SigOpMaskRules());
        }

        public Outcome EmitSigProductions(ReadOnlySpan<SdmOpCodeDetail> src, bool check = false)
        {
            var result = Outcome.Success;
            var sigs = SdmOps.sigs(src);
            var count = sigs.Length;
            var buffer = text.buffer();
            var dst = alloc<AsmSigProduction>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var sig = ref sigs[i];
                var expr = Symbolize(sig);
                seek(dst,i) = new AsmSigProduction(sig, expr);
            }

            var path = SdmPaths.SigProductions();
            var emitting = EmittingFile(path);
            Rules.emit(dst, path);
            EmittedFile(emitting, count);

            if(check)
            {
                result = ValidateHydration(dst);
            }
            return result;
        }

        Outcome ValidateHydration(Index<AsmSigProduction> src)
        {
            var count = src.Count;
            var output = LoadSigProductions();
            var result = Outcome.Success;
            if(count != output.Count)
                result = (false,string.Format("Record count mismatch: {0} != {1}", count, output.Count));

            if(result.Fail)
                return result;

            for(var i=0; i<count; i++)
            {
                ref readonly var expect = ref src[i];
                ref readonly var actual = ref output[i];

                if(actual == null)
                {
                    result = (false, string.Format("Null production for '{0}'", expect.Source));
                    break;

                }

                if(actual.Source == null)
                {
                    result = (false, string.Format("Source for '{0}' is null",  expect.Source));
                    break;
                }

                if(!actual.Target.IsValid)
                {
                    result = (false, string.Format("Target for '{0}' is invalid",  expect.Target));
                    break;
                }

                if(!expect.Source.Content.Equals(actual.Source.Content))
                {
                    result = (false, string.Format("'{0}' != '{1}'",  expect.Source, actual.Source));
                    break;
                }

                if(actual.Target == null)
                {
                    result = (false, string.Format("Target for '{0}' is null",  expect.Target));
                    break;
                }

                if(!expect.Target.Format().Equals(actual.Target.Format()))
                {
                    result = (false, string.Format("'{0}' != '{1}'",  expect.Target, actual.Target));
                    break;
                }
            }
            return result;
        }

        public Index<AsmSigTerminal> EmitTerminals()
        {
            var rules = LoadSigProductions();
            var count = rules.Length;
            var productions = list<AsmSigProduction>();
            for(var i=0; i<count; i++)
            {
                ref readonly var rule = ref rules[i];
                var terminals = rule.Target.Terminate();
                for(var j=0; j<terminals.Count; j++)
                    productions.Add(new AsmSigProduction(rule.Source, terminals[j]));
            }

            var prodCount = productions.Count;
            var records = alloc<AsmSigTerminal>(prodCount);
            for(var i=0u; i<prodCount; i++)
            {
                ref var record = ref seek(records,i);
                record.Seq = i;
                record.Source = productions[(int)i].Source;
                record.Target = productions[(int)i].Target;
            }

            var dst = ProjectDb.TablePath<AsmSigTerminal>("sdm");
            TableEmit(@readonly(records), AsmSigTerminal.RenderWidths, dst);

            return records;
        }

        Outcome Parse(string src, out AsmSigProduction dst)
        {
            var result = Outcome.Success;
            dst = AsmSigProduction.Empty;
            result = RuleText.parse(src, out IProduction prod);
            if(result)
            {
                result = AsmSigExpr.parse(prod.Source.Format(), out var sig);
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
            result = AsmSigExpr.parse(src, out var sig);
            if(result)
            {
                var ops = sig.Operands();
                var count = (byte)ops.Length;
                dst = new AsmSigRuleExpr(sig.Mnemonic, count);
                for(byte i=0; i<count; i++)
                {
                    ref readonly var op = ref skip(ops,i);
                    result = RuleText.parse(op.Text, out IRuleExpr expr);

                    if(result)
                        dst.WithOperand(i, expr);
                    else
                        break;
                }
            }
            return result;
        }

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

        public AsmSigRuleExpr Symbolize(in AsmSigExpr sig)
        {
            var opcount = sig.OperandCount;
            var operands = sig.Operands();
            var expr = new AsmSigRuleExpr(sig.Mnemonic, opcount);
            for(byte i=0; i<opcount; i++)
            {
                ref readonly var op = ref skip(operands,i);
                var key = op.Text;
                if(DecompRules.Find(key, out var production))
                    expr.WithOperand(i, production.Consequent);
                else
                    expr.WithOperand(i, Rules.value(op.Text));
            }

            Require.invariant(expr.IsValid, () => expr.Mnemonic.Format());
            return expr;
        }
   }
}