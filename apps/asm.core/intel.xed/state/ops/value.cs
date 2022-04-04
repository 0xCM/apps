//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline)]
        public static FieldValue value<T>(FieldKind kind, T value)
            where T : unmanaged
                => new FieldValue(kind, core.bw64(value));

        [MethodImpl(Inline)]
        public static FieldValue value(FieldKind kind, NameResolver resolver)
            => new FieldValue(kind, (ulong)resolver);
    }
}