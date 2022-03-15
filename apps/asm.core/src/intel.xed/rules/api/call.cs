//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static RuleCall call(FieldKind field, RuleOperator op, string target)
            => new RuleCall(field, op, NameResolvers.Instance.Create(target));
    }
}