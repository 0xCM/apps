//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline)]
        public static FieldValue<T> value<T>(FieldKind kind, FormatCode code, T value)
            where T : unmanaged
                => new FieldValue<T>(kind, code, value);

        [MethodImpl(Inline)]
        public static FieldValue value(FieldKind kind, NameResolver resolver)
            => new FieldValue(kind, FormatCode.Text, (ulong)resolver);
    }
}