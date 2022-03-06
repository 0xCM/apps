//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedRules.SyntaxLiterals;

    using FK = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using CK = XedRules.CriterionKind;

    partial class XedRules
    {
        public readonly struct RuleTables
        {
            static XedParsers Parsers => XedParsers.create();

            public static Outcome spec(string spec, CriterionKind ck, out CriterionSpec dst)
            {
                var input = text.trim(text.despace(spec));
                var fk = FK.INVALID;
                var op = RO.None;
                var fv = input;
                var name = EmptyString;
                var i = -1;
                var opsym = EmptyString;
                dst = CriterionSpec.Empty;
                if(text.contains(input, "()"))
                {
                    op = RO.Call;
                    opsym = "()";
                    i = text.index(input, '(');
                    fv = text.left(input,i);
                    if(Parsers.Nonterm(fv, out var nt))
                        dst = criterion(ck == CriterionKind.Premise, nt);
                    else
                        dst = criterion(ck == CriterionKind.Premise, NameResolvers.Instance.Create(fv));
                    return true;
                }
                else if(text.contains(input, "=="))
                {
                    op = RO.CmpEq;
                    opsym = "==";
                    i= text.index(input, "==");
                    name = text.left(input,i);
                    fv = text.right(input, i + opsym.Length - 1);
                }
                else if(text.contains(input, "!="))
                {
                    op = RO.CmpNeq;
                    opsym = "!=";
                    i= text.index(input, "!");
                    name = text.left(input,i);
                    fv = text.right(input, i + opsym.Length - 1);
                }
                else if(text.contains(input, "="))
                {
                    op = RO.Assign;
                    opsym = "=";
                    i = text.index(input, "=");
                    name = text.left(input,i);
                    fv = text.right(input, i + opsym.Length - 1);
                }
                else if(text.contains(input,"UIMM0[") || text.contains(input, "DISP[") || text.contains(input, "UIMM1["))
                {
                    name = text.left(input, text.index(input,'['));
                    Parsers.Parse(name, out fk);
                }

                if(nonempty(name) && fk == 0)
                {
                    if(name.Equals(REXW))
                        fk = FK.REXW;
                    else if(name.Equals(REXB))
                        fk = FK.REXB;
                    else if(name.Equals(REXR))
                        fk = FK.REXR;
                    else if(name.Equals(REXX))
                        fk = FK.REXX;
                    else if(!FieldKinds.ExprKind(name, out fk))
                        return (false, AppMsg.ParseFailure.Format(name, spec));
                }

                return XedRules.criterion(ck, fk, op, fv, out dst);
            }

            public static Index<CriterionSpec> specs(string src, CriterionKind kind)
            {
                var parts = text.trim(text.split(src, Chars.Space)).Where(x => nonempty(x) && !Skip.Contains(x));
                var count = parts.Length;
                var buffer = alloc<CriterionSpec>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    ref var dst = ref seek(buffer,i);
                    var result = spec(part, kind, out seek(buffer,i));
                    if(result.Fail)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(CriterionSpec), part));
                }
                return buffer;
            }

            public static RuleTable table(in RuleTermTable src)
            {
                var buffer = alloc<RuleExpr>(src.Expressions.Count);
                for(var i=0; i<src.Expressions.Count; i++)
                {
                    ref readonly var input = ref src.Expressions[i];
                    var p = specs(input.Premise.Map(x=> x.Format()).Delimit(Chars.Space).Format(), CriterionKind.Premise);
                    var c = specs(input.Consequent.Map(x=> x.Format()).Delimit(Chars.Space).Format(), CriterionKind.Consequent);
                    seek(buffer,i) = new RuleExpr(0, p,c);
                }
                var dst = RuleTable.Empty;
                dst.Expressions = buffer;
                dst.Name = src.Name;
                dst.ReturnType = src.ReturnType;
                return dst;
            }

            public static RuleExpr expr(RuleFormKind kind, string premise, string consequent = EmptyString)
            {
                var left = sys.empty<CriterionSpec>();
                var right = sys.empty<CriterionSpec>();
                if(nonempty(premise))
                    left = specs(premise, CK.Premise);

                if(nonempty(consequent))
                    right = specs(consequent, CK.Consequent);

                return new RuleExpr(kind, left, right);
            }

           static HashSet<string> Skip;

            static RuleTables()
            {
                Skip = hashset("VEXED_REX", "XED_RESET");
            }
        }
    }
}