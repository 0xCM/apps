//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedFormatters;

    class XedRuleChecks : AppService<XedRuleChecks>
    {
        XedRules Rules => Service(Wf.XedRules);

        IntelXed Xed => Service(Wf.IntelXed);

        XedPaths XedPaths => Service(Wf.XedPaths);

        AppDb AppDb => Service(Wf.AppDb);

        protected override void Initialized()
        {

        }


        public Outcome CheckRules()
        {
            var rules = Xed.Rules.ExpandMacros(Xed.Rules.CalcRuleSet(RuleSetKind.EncDec));

            return true;
        }
        public Outcome CheckEncRules()
        {
            var set = Rules.CalcRuleSet(RuleSetKind.Enc);
            Rules.ExpandMacros(set);
            TraverseTables(set);
            return true;
        }

        public Outcome CheckDecRules()
        {
            var set = Rules.CalcRuleSet(RuleSetKind.Dec);
            Rules.ExpandMacros(set);
            TraverseTables(set);
            return true;
        }

        public Outcome CheckEncDecRules()
        {
            var set = Rules.CalcRuleSet(RuleSetKind.EncDec);
            Rules.ExpandMacros(set);
            TraverseTables(set);
            return true;
        }

        public Outcome CheckRuleSeq()
        {
            var src = Rules.CalcRuleSeq();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var seq = ref src[i];
                Write(seq.Format());
            }
            return true;
        }

        void TraverseTables(RuleSet src)
        {
            var dst = XedPaths.RuleTableExp(src.Kind);
            var emitting = EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.AsciWriter();

            void OnCheck(string src)
            {
                writer.WriteLine(src);
                counter++;
            }

            Traverse(src.Tables, OnCheck);

            EmittedFile(emitting, counter);
        }

        void Traverse(ReadOnlySpan<RuleTable> src, Action<string> f)
        {
            for(var i=0; i<src.Length; i++)
                Traverse(skip(src,i), f);
        }

        void Traverse(in RuleTable src, Action<string> f)
        {
            const string SigPattern = "public static void {0}(in MachineRequest req, ref RuleState state)";
            var expressions = src.Expressions;
            var dst = text.buffer();

            if(expressions.Count == 1 && expressions.First.IsVacant)
            {
                dst.Append(string.Format(SigPattern, src.Name));
                dst.AppendLine("{}");
                return;
            }

            dst.AppendLineFormat(SigPattern,src.Name);
            dst.AppendLine(Chars.LBrace);

            void OnExpr(string expr)
            {
                dst.IndentLine(4, expr);
            }

            Traverse(src.Expressions, OnExpr);

            dst.AppendLine(Chars.RBrace);
            f(dst.Emit());
        }

        void Traverse(ReadOnlySpan<RuleExpr> src, Action<string> f)
        {
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var expr = ref skip(src,i);
                Traverse(expr,f);
            }
        }

        void Traverse(in RuleExpr src, Action<string> f)
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
                Traverse(src.Premise[i], OnPremise);

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
                Traverse(src.Consequent[i], OnConsequent);

            f(dst.Emit());
        }

        const string DefaultExpr = "_default";

        const string NothingExpr = "_.";

        void Traverse(in RuleCriterion src, Action<string> f)
        {
            if(src.IsPremise && src.IsDefault)
            {
                f(DefaultExpr);
            }
            else if(src.IsConsequent && src.IsVacant)
            {
                f(NothingExpr);
            }
            else
            {
                if(src.Operator == RuleOperator.Call)
                {
                    f(string.Format("{1}{0}", format(src.Operator), src.Value));
                }
                else
                {
                    f(string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), src.Value));
                }
            }
        }
    }
}