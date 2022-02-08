//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRecords;
    using static core;
    using static Root;

    partial class XedRules
    {
        Index<RuleCriterion> ParseRuleCriteria(string src)
        {
            var left = text.trim(text.split(src, Chars.Space));
            var count = left.Length;
            var buffer = alloc<RuleCriterion>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref skip(left, i);
                if(empty(spec))
                    continue;

                ref var dst = ref seek(buffer,i);
                var fk = XedOpKind.INVALID;
                var op = RuleOperator.None;
                var fv = EmptyString;
                var j = text.index(spec, Chars.Eq);
                var k = text.index(spec, "!=");
                var name = EmptyString;

                if(k >= 0)
                {
                    op = RuleOperator.Neq;
                    name = text.left(spec,k);
                    fv = text.right(spec,k + "!=".Length + 1);
                }
                else if(j >=0)
                {
                    op = RuleOperator.Eq;
                    name = text.left(spec,j);
                    fv = text.right(spec,j);
                }
                else
                {
                    fv = spec;
                }

                if(nonempty(name))
                {
                    if(name.Equals("REXW[w]"))
                        fk = XedOpKind.REXW;
                    else if(name.Equals("REXB[b]"))
                        fk = XedOpKind.REXB;
                    else if(name.Equals("REXR[r]"))
                        fk = XedOpKind.REXR;
                    else if(name.Equals("REXX[x]"))
                        fk = XedOpKind.REXX;
                    else if(!OperandKinds.ExprKind(name, out fk))
                        Warn(string.Format("Kind for {0} not found in {1}", name, src));
                }

                dst = new RuleCriterion(fk, op, fv);
            }
            return buffer;
        }
    }
}