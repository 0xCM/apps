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
        public static FieldCmp neq<T>(FieldValue<T> src)
            where T : unmanaged
                => new FieldCmp(src.Kind, RuleOperator.CmpNeq, core.bw64(src.Data));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static FieldCmp eq<T>(FieldValue<T> src)
            where T : unmanaged
                => new FieldCmp(src.Kind, RuleOperator.CmpEq, core.bw64(src.Data));
    }
}