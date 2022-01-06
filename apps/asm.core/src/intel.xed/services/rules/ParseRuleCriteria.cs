//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
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
                var fk = OperandKind.INVALID;
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
                    if(!OperandKinds.ExprKind(name, out fk))
                        Warn(string.Format("Kind for {0} not found in {1}", name, src));
                }

                dst = new RuleCriterion(fk, op, fv);
            }
            return buffer;
        }
    }
}