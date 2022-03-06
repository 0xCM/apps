//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static FieldCmp neq<T>(FieldKind field, T value)
            where T : unmanaged
                => new FieldCmp(field, RuleOperator.CmpNeq, core.bw64(value));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static FieldCmp eq<T>(FieldKind field, T value)
            where T : unmanaged
                => new FieldCmp(field, RuleOperator.CmpEq, core.bw64(value));
    }
}