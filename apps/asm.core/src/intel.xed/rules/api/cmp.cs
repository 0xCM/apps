//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static FieldCmp neq(FieldValue a, FieldValue b)
        //     => new FieldCmp(a, RuleOperator.CmpNeq, b);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static FieldCmp eq(FieldValue a, FieldValue b)
        //     => new FieldCmp(a, RuleOperator.CmpEq, b);

        public static FieldCmp cmp(FieldValue a, RuleOperator op, FieldValue b)
            => new FieldCmp(a,op,b);
    }
}