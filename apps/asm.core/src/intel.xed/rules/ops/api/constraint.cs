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
        public static FieldConstraint<T> constraint<T>(FieldKind field, ConstraintKind kind, T value)
            where T : unmanaged
                => new FieldConstraint<T>(field, kind, value);
    }
}