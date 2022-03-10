//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static bool eval(in FieldCmp cmp)
        {
            var result = false;
            if(cmp.Operator == RuleOperator.CmpEq)
                result = cmp.Left == cmp.Right;
            else if(cmp.Operator == RuleOperator.CmpEq)
                result = cmp.Left != cmp.Right;
            return result;
        }

        [Op]
        public static bool eval(in RuleState state, in RuleExpr expr, ref RuleState dst)
        {
            var result = true;
            for(var i=0; i<expr.Premise.Count; i++)
            {
                ref readonly var p = ref expr.Premise[i];
                var a = select(p.Field, state);
                var b = value(p.Field, p.Data);
                if(!eval(cmp(a, p.Operator, b)))
                    break;
            }

            if(result)
            {
                for(var i=0; i<expr.Consequent.Count; i++)
                {
                    ref readonly var c = ref expr.Consequent[i];
                    update(value(c.Field, c.Data), ref dst);
                }
            }
            return result;
        }
    }
}