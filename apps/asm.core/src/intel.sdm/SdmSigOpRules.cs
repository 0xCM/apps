//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

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

        public void EmitSigProductions(ReadOnlySpan<SdmOpCodeDetail> src, bool check = false)
        {
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
                var result = ValidateHydration(dst);
                if(result.Fail)
                    Error(result.Message);
            }
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
                if(!expect.Source.Content.Equals(actual.Source.Content))
                {
                    result = (false, string.Format("'{0}' != '{1}'",  expect.Source, actual.Source));
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
            var dst = dict<byte,IRuleExpr>();
            var operands = sig.Operands();
            for(byte i=0; i<opcount; i++)
            {
                ref readonly var op = ref skip(operands,i);
                var key = op.Text;
                if(DecompRules.Find(key, out var choices))
                {
                    dst[i] = Rules.choices(choices);
                }
                else
                {
                    dst[i] = RuleText.value(op.Text);
                }
            }

            var xyz = SymbolizeOpMasks(dst);
            var _xyzCount = (byte)xyz.EntryCount;
            var expr = new AsmSigRuleExpr(sig.Mnemonic,_xyzCount);
            for(byte i=0; i<_xyzCount; i++)
            {
                expr.WithOperand(i,xyz[i]);
            }
            return expr;
        }

        ConstLookup<byte,IRuleExpr> SymbolizeOpMasks(ConstLookup<byte,IRuleExpr> src)
        {
            var opcount = src.EntryCount;
            var dst = dict<byte,IRuleExpr>();
            var i = z8;
            foreach(var entry in src.Entries)
            {
                var input = entry.Value;
                if(DecomposeOpMasks(input, out var val, out var opt))
                {
                    dst[i++] = val;
                    dst[i++] = opt;
                }
                else
                    dst[i++] = input;
            }
            return dst;
        }

        bool DecomposeOpMasks(IRuleExpr src, out IRuleExpr value, out IOptionRule option)
        {
            if(OpMaskRules.Find(src.Format(), out var decomp))
            {
                value = Rules.value(decomp[0]);
                option = Rules.option(decomp[1]);
                return true;
            }
            else
            {
                value = default;
                option = default;
                return false;
            }
        }
    }
}