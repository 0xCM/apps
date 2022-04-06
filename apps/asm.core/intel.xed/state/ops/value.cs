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
        public static CellValue value<T>(FieldKind kind, T value)
            where T : unmanaged
                => new CellValue(kind, core.bw64(value));

        [MethodImpl(Inline)]
        public static CellValue value(FieldKind kind, NameResolver resolver)
            => new CellValue(kind, (ulong)resolver);
    }
}