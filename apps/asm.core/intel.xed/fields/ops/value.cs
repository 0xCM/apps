//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    using R = XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline)]
        public static R.FieldValue value<T>(FieldKind kind, T value)
            where T : unmanaged
                => new R.FieldValue(kind, core.bw64(value));

        [MethodImpl(Inline)]
        public static R.FieldValue value(FieldKind kind, NameResolver resolver)
            => new R.FieldValue(kind, (ulong)resolver);
    }
}