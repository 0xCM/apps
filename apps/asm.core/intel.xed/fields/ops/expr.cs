//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using R = XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static FieldExpr expr(FieldKind field, RuleOperator op, R.FieldValue value)
            => new (field,op,value);
    }
}