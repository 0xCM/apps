//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;

    class XedRuleChecks : AppService<XedRuleChecks>
    {
        XedRules Rules => Service(Wf.XedRules);

        IntelXed Xed => Service(Wf.IntelXed);

        ConstLookup<string,MacroSpec> Macros;

        protected override void Initialized()
        {
            var macros = XedRules.macros();
            var names = Symbols.index<RuleMacroName>();
            Macros = XedRules.macros().Map(x => (names[x.Name].Expr.Format(), x)).ToDictionary();
        }

        public Outcome CheckEncRules()
        {
            var set = Rules.CalcRuleSet(RuleSetKind.Enc);
            Rules.ExpandMacros(set);
            Check(set.Tables);

            return true;
        }

        void Check(ReadOnlySpan<RuleTable> src)
        {
            for(var i=0; i<src.Length; i++)
                Check(skip(src,i));
        }

        void Check(in RuleTable src)
        {
            var table = src;
            var dst = text.buffer();

            dst.AppendLineFormat("public static void {0}(in MachineRequest req, ref RuleState state)",src.Name);
            dst.AppendLine(Chars.LBrace);

            void OnExpr(string expr)
            {
                dst.IndentLine(4, expr);
            }

            Check(src.Expressions, OnExpr);

            dst.AppendLine(Chars.RBrace);
            Write(dst.Emit());
        }

        void Check(ReadOnlySpan<XedRules.RuleExpr> src, Action<string> f)
        {
            for(var i=0; i<src.Length; i++)
                Check(skip(src,i),f);
        }

        void Check(in XedRules.RuleExpr src, Action<string> f)
        {
            var dst = text.buffer();
            var counter = 0;
            void OnPremise(string src)
            {
                if(counter == 0)
                    dst.Append(src);
                else
                    dst.AppendFormat(" && {0}", src);
            }

            void OnConsequent(string src)
            {
                if(counter == 0)
                    dst.Append(src);
                else
                    dst.AppendFormat(" {0}", src);
            }


            for(var i=0; i<src.Premise.Count; i++, counter++)
            {
                Check(src.Premise[i], OnPremise);
            }

            switch(src.Kind)
            {
                case RuleFormKind.EncodeStep:
                    dst.Append(" -> ");
                break;
                case RuleFormKind.DecodeStep:
                    dst.Append(" | ");
                break;
                default:
                    dst.Append(" ? ");
                break;
            }

            counter = 0;
            for(var i=0; i<src.Consequent.Count; i++, counter++)
            {
                Check(src.Consequent[i], OnConsequent);
            }

            f(dst.Emit());
        }


        void Check(in RuleCriterion src, Action<string> f)
        {
            if(src.Operator == RuleOperator.Call)
            {
                f(string.Format("{1}{0}", format(src.Operator), src.Value));
            }
            else
            {
                // var result = XedRules.spec(src, out var spec);
                // if(result.Fail)
                // {
                //     Warn(string.Format("Spec creation failed for {0}", src.Format()));
                //     return;
                // }

                f(string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), src.Value));
            }
        }
    }
}